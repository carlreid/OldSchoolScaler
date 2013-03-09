using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OldSchoolScaler
{
    public partial class Form1 : Form
    {

        ClientForm rsForm;

        float rsRatio = 1.53f;

        public int lastMousePosX = 0;
        public int lastMousePosY = 0;
        bool isMouseClick = false;
        bool menuDown = false;

        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int X;
            public int Y;
            public static implicit operator Point(POINT point)
            {
                return new Point(point.X, point.Y);
            }
        }

        #region User32 -  Move to User32.cs?
        [DllImport("user32.dll")]
        static extern bool SetCursorPos(int X, int Y);
        [DllImport("user32.dll")]
        public static extern bool GetCursorPos(out POINT lpPoint);
        [DllImport("user32.dll")]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);
        [DllImport("user32.dll")]
        static extern bool ClientToScreen(IntPtr hWnd, ref Point lpPoint);
        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll", EntryPoint = "WindowFromPoint", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr WindowFromPoint(Point point);
        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string lpClassName,string lpWindowName);
        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll")]
        public static extern IntPtr PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);
        [DllImport("user32")]
        static extern int MapVirtualKey(Keys uCode, int uMapType);
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindowEx(IntPtr parentHandle, IntPtr childAfter, string className, string windowTitle);
        [DllImport("user32")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnumChildWindows(IntPtr window, EnumWindowProc callback, IntPtr i);
        #endregion

        public delegate bool EnumWindowProc(IntPtr hWnd, IntPtr parameter);

        //Windows message IDs
        //private const int BM_CLICK = 0x00F5;
        //const int VK_TAB = 0x09;
        //const int VK_ENTER = 0x0D;
        //const int VK_UP = 0x26;
        //const int VK_DOWN = 0x28;
        //const int VK_RIGHT = 0x27;
        //const int WM_PARENTNOTIFY = 0x0210;
        //const int WM_MOUSEACTIVATE = 0x0021;
        const uint WM_KEYDOWN = 0x0100;
        const uint WM_KEYUP = 0x0101;
        const uint WM_CHAR = 0x0102;
        const uint WM_SETFOCUS = 0x0007;
        const uint WM_KILLFOCUS = 0x0008;
        const int cap = 1048576;
        const int WM_LBUTTONDOWN = 0x0201;
        const int WM_LBUTTONUP = 0x0202;
        const int WM_MOUSEMOVE = 0x0200;
        const int WM_MOUSEWHEEL = 0x020A;
        const int WM_RBUTTONDOWN = 0x0204;
        const int WM_RBUTTONUP = 0x0205;
        const int WM_SETCURSOR = 0x0020;
        const int WM_NCHITTEST = 0x84;


        public Form1()
        {
            InitializeComponent();

            //Add mouse wheen event handler, couldn't seem to find it under the design view
            blowUpPictureBox.MouseWheel += new MouseEventHandler(blowUpMouseWheel);

            //Add worlds to world selector
            int maxWorlds = 78;
            int[] nonExistWorlds = {23, 24, 31, 32, 39, 40, 47, 48, 55, 56, 63, 64, 71, 72};
            for (int world = 1; world <= maxWorlds; ++world)
            {
                foreach (int deadWorld in nonExistWorlds)
                {
                    if (world == deadWorld)
                        continue;
                }
                worldComboBox.Items.Add(world.ToString());
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Setup the client form
            rsForm = new ClientForm();
            rsForm.myOwner = this;
            rsForm.Show();

            //Setup this form's controls to a default setup
            blowUpPictureBox.Focus();
            menuPanel.Height = 0;
            panelToggleBox.Top = menuPanel.Bottom;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //Sample the client form and display it in the picture box
            //Probably not great having it on a timer, maybe switch to background worker.
            if (blowUpPictureBox.Image != null)
            {
                blowUpPictureBox.Image.Dispose();
            }
            blowUpPictureBox.Image = ControlExtensions.DrawToImage(rsForm.clientBrowser);
        }

        //Get a list of all the child windows of a parent.
        //From: http://www.pinvoke.net/default.aspx/user32/enumchildwindows.html
        public static List<IntPtr> GetChildWindows(IntPtr parent)
        {
            List<IntPtr> result = new List<IntPtr>();
            GCHandle listHandle = GCHandle.Alloc(result);
            try
            {
                EnumWindowProc childProc = new EnumWindowProc(EnumWindow);
                EnumChildWindows(parent, childProc, GCHandle.ToIntPtr(listHandle));
            }
            finally
            {
                if (listHandle.IsAllocated)
                    listHandle.Free();
            }
            return result;
        }

        //Needed for GetChildWindows
        //From: http://www.pinvoke.net/default.aspx/user32/enumchildwindows.html
        private static bool EnumWindow(IntPtr handle, IntPtr pointer)
        {
            GCHandle gch = GCHandle.FromIntPtr(pointer);
            List<IntPtr> list = gch.Target as List<IntPtr>;
            if (list == null)
                throw new InvalidCastException("GCHandle Target could not be cast as List<IntPtr>");

            list.Add(handle);
            return true;
        }

        //Toggles the menu up and down
        public void menuPanelToggle()
        {
            if (menuDown)
            {
                menuPanel.Height = 0;
                menuDown = !menuDown;
                panelToggleBox.Top = menuPanel.Bottom;
                blowUpPictureBox.Top = menuPanel.Bottom;
                Debug.WriteLine("Menu was down");
            }
            else
            {
                menuPanel.Height = 50;
                menuDown = !menuDown;
                panelToggleBox.Top = menuPanel.Bottom;
                blowUpPictureBox.Top = menuPanel.Bottom;
                Debug.WriteLine("Menu was up");
            }
            resizeGameWindow();
        }

        private void keyPress(object sender, KeyEventArgs e)
        {
            //Used to toggle menu as a shortcut - somewhat sketchy due to keystrokes not always needing to be forwarded.
            //First key is forwarded and thereafter the other window is on focus so other keys are not forwarded.
            if (e.KeyCode == Keys.Escape)
            {
                menuPanelToggle();
                e.Handled = false;
                return;
            }

            //If typing in the worldComboBox instead of picking a world.
            if (worldComboBox.Focused)
            {
                e.Handled = false;
                return;
            }

            List<IntPtr> childWindows = GetChildWindows(rsForm.Handle);

            int curKey = e.KeyValue;

            int scanCode = MapVirtualKey(e.KeyCode, 0);
            int lparam = 0x00000001 | (scanCode << 16);

            //Useful in future (Alt/Control) - http://stackoverflow.com/questions/10280000/how-to-create-lparam-of-sendmessage-wm-keydown
            SendMessage(childWindows[childWindows.Count - 3], WM_SETFOCUS, (IntPtr)cap, IntPtr.Zero);
            PostMessage(childWindows[childWindows.Count - 3], WM_KEYDOWN, ((IntPtr)curKey), (IntPtr)lparam);

            //Debug.WriteLine("Key Down: " + e.KeyValue);

        }

        private void keyPressUp(object sender, KeyEventArgs e)
        {
            if (worldComboBox.Focused)
            {
                e.Handled = false;
                return;
            }
        }

        private void blowUpMouseWheel(object sender, MouseEventArgs e)
        {

            List<IntPtr> childWindows = GetChildWindows(rsForm.Handle);

            float scaleRatioX = (float)blowUpPictureBox.Width / (float)rsForm.clientBrowser.Width;
            float scaleRatioY = (float)blowUpPictureBox.Height / (float)rsForm.clientBrowser.Height;

            float mouseScaledX = ((float)e.X / (float)blowUpPictureBox.Width) * rsForm.clientBrowser.Width;
            float mouseScaledY = ((float)e.Y / (float)blowUpPictureBox.Height) * rsForm.clientBrowser.Height;

            const int HTCLIENT = 1;

            //Debug.WriteLine("Normal: X(" + e.X + "), Y(" + e.Y + ")");
            //Debug.WriteLine("Scaled: X(" + mouseScaledX + "), Y(" + mouseScaledY + ")");

            IntPtr lParam = (IntPtr)(((int)(rsForm.Top + mouseScaledY + 31 + Properties.Settings.Default.yOffsetMouse) << 16) | (int)(rsForm.Left + mouseScaledX + 10 + Properties.Settings.Default.xOffsetMouse));

            IntPtr lParamHittest = (IntPtr)(((int)WM_MOUSEMOVE << 16) | HTCLIENT);

            SendMessage(childWindows[childWindows.Count - 1], WM_SETCURSOR, childWindows[childWindows.Count - 1], (IntPtr)lParamHittest);
            PostMessage(childWindows[childWindows.Count - 1], WM_MOUSEWHEEL, IntPtr.Zero, lParam);
            SendMessage(childWindows[childWindows.Count - 1], WM_NCHITTEST, IntPtr.Zero, lParam);

            lastMousePosX = (int)mouseScaledX;
            lastMousePosY = (int)mouseScaledY;
            //blowUpPictureBox.Focus();
        }

        private void blowUpMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Control control = (Control)sender;
                control.Capture = false;
            }

            List<IntPtr> childWindows = GetChildWindows(rsForm.Handle);

            float scaleRatioX = (float)blowUpPictureBox.Width / (float)rsForm.clientBrowser.Width;
            float scaleRatioY = (float)blowUpPictureBox.Height / (float)rsForm.clientBrowser.Height;

            float mouseScaledX = ((float)e.X / (float)blowUpPictureBox.Width) * rsForm.clientBrowser.Width;
            float mouseScaledY = ((float)e.Y / (float)blowUpPictureBox.Height) * rsForm.clientBrowser.Height;

            const int HTCLIENT = 1;

            //Debug.WriteLine("Normal: X(" + e.X + "), Y(" + e.Y + ")");
            //Debug.WriteLine("Scaled: X(" + mouseScaledX + "), Y(" + mouseScaledY + ")");

            IntPtr lParam = (IntPtr)(((int)(rsForm.Top + mouseScaledY + 31 + Properties.Settings.Default.yOffsetMouse) << 16) | (int)(rsForm.Left + mouseScaledX + 10 + Properties.Settings.Default.xOffsetMouse));

            IntPtr lParamHittest = (IntPtr)(((int)WM_MOUSEMOVE << 16) | HTCLIENT);

            SendMessage(childWindows[childWindows.Count - 1], WM_SETCURSOR, childWindows[childWindows.Count - 1], (IntPtr)lParamHittest);
            PostMessage(childWindows[childWindows.Count - 1], WM_MOUSEMOVE, IntPtr.Zero, lParam);
            SendMessage(childWindows[childWindows.Count - 1], WM_NCHITTEST, IntPtr.Zero, lParam);

            lastMousePosX = (int)mouseScaledX;
            lastMousePosY = (int)mouseScaledY;
        }

        private void calibrateVoidLensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            voidLensesPanel.Visible = !voidLensesPanel.Visible;
            if (voidLensesPanel.Visible)
            {
                offsetXTrackBar.Value = Properties.Settings.Default.xOffsetMouse;
                offsetYTrackBar.Value = Properties.Settings.Default.yOffsetMouse;
                mouseClicksTrackBar.Value = Properties.Settings.Default.mouseClickAmount;

                labelXOffset.Text = Properties.Settings.Default.xOffsetMouse.ToString();
                labelYOffset.Text = Properties.Settings.Default.yOffsetMouse.ToString();
                labelClickAmount.Text = Properties.Settings.Default.mouseClickAmount.ToString();

            }
        }

        private void offsetXTrackBar_Scroll(object sender, EventArgs e)
        {
            labelXOffset.Text = offsetXTrackBar.Value.ToString();
            Properties.Settings.Default.xOffsetMouse = offsetXTrackBar.Value;
        }

        private void offsetYTrackBar_Scroll(object sender, EventArgs e)
        {
            labelYOffset.Text = offsetYTrackBar.Value.ToString();
            Properties.Settings.Default.yOffsetMouse = offsetYTrackBar.Value;
        }

        private void mouseClicksTrackBar_Scroll(object sender, EventArgs e)
        {
            labelClickAmount.Text = mouseClicksTrackBar.Value.ToString();
            Properties.Settings.Default.mouseClickAmount = mouseClicksTrackBar.Value;
        }

        private void toggleStretchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.isStretched = !Properties.Settings.Default.isStretched;

            if (Properties.Settings.Default.isStretched)
            {
                blowUpPictureBox.Left = this.ClientRectangle.Left;
                blowUpPictureBox.Top = menuPanel.Bottom;
                blowUpPictureBox.Width = this.ClientRectangle.Width;
                blowUpPictureBox.Height = this.ClientRectangle.Height - menuPanel.Bottom;
            }
            else
            {
                blowUpPictureBox.Top = menuPanel.Bottom;
                blowUpPictureBox.Height = this.ClientRectangle.Height - menuPanel.Bottom;

                int calcWidth = (int)(blowUpPictureBox.Height * rsRatio);
                blowUpPictureBox.Left = (this.Width / 2) - (calcWidth / 2);
                blowUpPictureBox.Width = calcWidth;
            }
        }

        private void blowUpMouseDown(object sender, MouseEventArgs e)
        {
            Debug.WriteLine("Mouse Down");
            List<IntPtr> childWindows = GetChildWindows(rsForm.Handle);

            float scaleRatioX = (float)blowUpPictureBox.Width / (float)rsForm.clientBrowser.Width;
            float scaleRatioY = (float)blowUpPictureBox.Height / (float)rsForm.clientBrowser.Height;

            float mouseScaledX = ((float)e.X / (float)blowUpPictureBox.Width) * rsForm.clientBrowser.Width;
            float mouseScaledY = ((float)e.Y / (float)blowUpPictureBox.Height) * rsForm.clientBrowser.Height;

            IntPtr lParam = (IntPtr)(((int)(rsForm.Top + mouseScaledY + 31 + Properties.Settings.Default.yOffsetMouse) << 16) | (int)(rsForm.Left + mouseScaledX + 10 + Properties.Settings.Default.xOffsetMouse));

            const int MK_LBUTTON = 0x0001;
            const int MK_RBUTTON = 0x0002;

            Debug.WriteLine("Normal: X(" + e.X + "), Y(" + e.Y + ")");
            Debug.WriteLine("Scaled: X(" + mouseScaledX + "), Y(" + mouseScaledY + ")");

            isMouseClick = true;

            if (e.Button == MouseButtons.Right)
            {
                //PostMessage(childWindows[childWindows.Count - 1], WM_MOUSEMOVE, (IntPtr)MK_LBUTTON, lParam);
                for (int click = 0; click < Properties.Settings.Default.mouseClickAmount; ++click)
                {
                    PostMessage(childWindows[childWindows.Count - 1], WM_RBUTTONDOWN, (IntPtr)MK_RBUTTON, lParam);
                }

            }

            if (e.Button == MouseButtons.Left)
            {
                //PostMessage(childWindows[childWindows.Count - 1], WM_MOUSEMOVE, (IntPtr)MK_LBUTTON, lParam);
                for (int click = 0; click < Properties.Settings.Default.mouseClickAmount; ++click)
                {
                    PostMessage(childWindows[childWindows.Count - 1], WM_LBUTTONDOWN, (IntPtr)MK_LBUTTON, lParam);
                }

            }
            //blowUpPictureBox.Focus();
        }

        private void blowUpMouseUp(object sender, MouseEventArgs e)
        {
            Debug.WriteLine("Mouse Up");
            List<IntPtr> childWindows = GetChildWindows(rsForm.Handle);

            float scaleRatioX = (float)blowUpPictureBox.Width / (float)rsForm.clientBrowser.Width;
            float scaleRatioY = (float)blowUpPictureBox.Height / (float)rsForm.clientBrowser.Height;

            float mouseScaledX = ((float)e.X / (float)blowUpPictureBox.Width) * rsForm.clientBrowser.Width;
            float mouseScaledY = ((float)e.Y / (float)blowUpPictureBox.Height) * rsForm.clientBrowser.Height;

            IntPtr lParam = (IntPtr)(((int)(rsForm.Top + mouseScaledY + 31 + Properties.Settings.Default.yOffsetMouse) << 16) | (int)(rsForm.Left + mouseScaledX + 10 + Properties.Settings.Default.xOffsetMouse));

            const int MK_LBUTTON = 0x0001;
            const int MK_RBUTTON = 0x0002;

            isMouseClick = false;

            if (e.Button == MouseButtons.Right)
            {
                //PostMessage(childWindows[childWindows.Count - 1], WM_MOUSEMOVE, (IntPtr)MK_LBUTTON, lParam);
                for (int click = 0; click < Properties.Settings.Default.mouseClickAmount; ++click)
                {
                    PostMessage(childWindows[childWindows.Count - 1], WM_RBUTTONUP, IntPtr.Zero, lParam);
                }

            }

            if (e.Button == MouseButtons.Left)
            {
                //PostMessage(childWindows[childWindows.Count - 1], WM_MOUSEMOVE, (IntPtr)MK_LBUTTON, lParam);
                for (int click = 0; click < Properties.Settings.Default.mouseClickAmount; ++click)
                {
                    PostMessage(childWindows[childWindows.Count - 1], WM_LBUTTONUP, (IntPtr)MK_LBUTTON, lParam);
                }

            }
            //blowUpPictureBox.Focus();
        }

        private void loadWorldButton_Click(object sender, EventArgs e)
        {
            int selectedWorld;
            if (Int32.TryParse(worldComboBox.Text, out selectedWorld))
            {
                rsForm.clientBrowser.Navigate("http://oldschool" + selectedWorld.ToString() + ".runescape.com/j1", null, null, "Old School Scaler\r\n");
            }
            else
            {
                MessageBox.Show("Please enter a number.", "Invalid World", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void resizeGameWindow()
        {
            if (Properties.Settings.Default.isStretched)
            {
                blowUpPictureBox.Left = this.ClientRectangle.Left;
                blowUpPictureBox.Top = menuPanel.Bottom - 50;
                blowUpPictureBox.Width = this.ClientRectangle.Width;
                blowUpPictureBox.Height = (this.ClientRectangle.Height - menuPanel.Bottom) + 60;
            }
            else
            {
                blowUpPictureBox.Top = menuPanel.Bottom - 50;
                blowUpPictureBox.Height = (this.ClientRectangle.Height - menuPanel.Bottom) + 60;

                int calcWidth = (int)(blowUpPictureBox.Height * rsRatio);
                blowUpPictureBox.Left = (this.Width / 2) - (calcWidth / 2);
                blowUpPictureBox.Width = calcWidth;
            }
        }

        private void resizePictureBox_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.isStretched = !Properties.Settings.Default.isStretched;
            resizeGameWindow();
        }

        private void calibratePictureBox_Click(object sender, EventArgs e)
        {
            voidLensesPanel.Visible = !voidLensesPanel.Visible;
            if (voidLensesPanel.Visible)
            {
                offsetXTrackBar.Value = Properties.Settings.Default.xOffsetMouse;
                offsetYTrackBar.Value = Properties.Settings.Default.yOffsetMouse;
                mouseClicksTrackBar.Value = Properties.Settings.Default.mouseClickAmount;

                labelXOffset.Text = Properties.Settings.Default.xOffsetMouse.ToString();
                labelYOffset.Text = Properties.Settings.Default.yOffsetMouse.ToString();
                labelClickAmount.Text = Properties.Settings.Default.mouseClickAmount.ToString();

            }
        }

        private void panelToggleBox_Click(object sender, EventArgs e)
        {
            menuPanelToggle();
            
        }

        private void onFormResize(object sender, EventArgs e)
        {
            resizeGameWindow();
        }

        private void programEnding(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Save();
        }


    }


}
