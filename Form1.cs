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

        int mouseXOffset = 0;
        int mouseYOffset = 0;
        int mouseClickAmount = 1;
        bool isStretched = false;
        float rsRatio = 1.53f;

        int lastMousePosX = 0;
        int lastMousePosY = 0;
        bool isMouseClick = false;

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

        [DllImport("user32.dll")]
        static extern bool SetCursorPos(int X, int Y);

        [DllImport("user32.dll")]
        public static extern bool GetCursorPos(out POINT lpPoint);

        [DllImport("user32.dll")]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

        [DllImport("user32.dll")]
        static extern bool ClientToScreen(IntPtr hWnd, ref Point lpPoint);

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int Msg,
            IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", EntryPoint = "WindowFromPoint",
            CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr WindowFromPoint(Point point);

        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string lpClassName,string lpWindowName);

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll")]
        public static extern IntPtr PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32")]
        static extern int MapVirtualKey(Keys uCode, int uMapType);

        //[DllImport("user32.dll", SetLastError = true)]
        //static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindowEx(IntPtr parentHandle, IntPtr childAfter, string className, string windowTitle);

        public delegate bool EnumWindowProc(IntPtr hWnd, IntPtr parameter);

        [DllImport("user32")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnumChildWindows(IntPtr window, EnumWindowProc callback, IntPtr i);


        //private const int BM_CLICK = 0x00F5;
        const uint WM_KEYDOWN = 0x0100;
        const uint WM_KEYUP = 0x0101;
        const uint WM_CHAR = 0x0102;
        //const int VK_TAB = 0x09;
        //const int VK_ENTER = 0x0D;
        //const int VK_UP = 0x26;
        //const int VK_DOWN = 0x28;
        //const int VK_RIGHT = 0x27;
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
        //const int WM_PARENTNOTIFY = 0x0210;
        //const int WM_MOUSEACTIVATE = 0x0021;
        const int WM_NCHITTEST = 0x84;


        public Form1()
        {
            InitializeComponent();

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
            //worldComboBox.Visible = false;
            //loadWorldButton.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            rsForm = new ClientForm();
            rsForm.myOwner = this;
            rsForm.Show();

            blowUpPictureBox.Focus();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //rsForm.clientBrowser.Invalidate();
            if (blowUpPictureBox.Image != null)
            {
                blowUpPictureBox.Image.Dispose();
            }
            blowUpPictureBox.Image = ControlExtensions.DrawToImage(rsForm.clientBrowser);



            //////if (isRightClick)
            //////{
            //////    return;
            //////}
            ////List<IntPtr> childWindows = GetChildWindows(rsForm.Handle);

            ////float scaleRatioX = (float)blowUpPictureBox.Width / (float)rsForm.clientBrowser.Width;
            ////float scaleRatioY = (float)blowUpPictureBox.Height / (float)rsForm.clientBrowser.Height;

            ////IntPtr lParam = (IntPtr)(((int)(rsForm.Top + lastMousePosY + 31 + mouseYOffset) << 16) | (int)(rsForm.Left + lastMousePosX + 10 + mouseXOffset));

            //////PostMessage(childWindows[childWindows.Count - 1], WM_MOUSEMOVE, IntPtr.Zero, lParam);
            //////SendMessage(childWindows[childWindows.Count - 1], WM_NCHITTEST, IntPtr.Zero, lParam);


        }

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

        private static bool EnumWindow(IntPtr handle, IntPtr pointer)
        {
            GCHandle gch = GCHandle.FromIntPtr(pointer);
            List<IntPtr> list = gch.Target as List<IntPtr>;
            if (list == null)
                throw new InvalidCastException("GCHandle Target could not be cast as List<IntPtr>");

            list.Add(handle);
            return true;
        }

        private void keyPress(object sender, KeyEventArgs e)
        {
            if (worldComboBox.Focused)
            {
                e.Handled = false;
                return;
            }

            List<IntPtr> childWindows = GetChildWindows(rsForm.Handle);

            int curKey = e.KeyValue;

            int scanCode = MapVirtualKey(e.KeyCode, 0);
            int lparam = 0x00000001 | (scanCode << 16);

            //SendMessage(childWindows[childWindows.Count - 3], WM_SETFOCUS, (IntPtr)cap, IntPtr.Zero);
            //PostMessage(childWindows[childWindows.Count - 3], WM_KEYDOWN, ((IntPtr)curKey), (IntPtr)lparam);
            ////PostMessage(childWindows[childWindows.Count - 3], WM_KEYUP, ((IntPtr)curKey), (IntPtr)lparam);

            //rsForm.clientBrowser.Focus();


            //Useful in future (Alt/Control) - http://stackoverflow.com/questions/10280000/how-to-create-lparam-of-sendmessage-wm-keydown
            SendMessage(childWindows[childWindows.Count - 3], WM_SETFOCUS, (IntPtr)cap, IntPtr.Zero);
            PostMessage(childWindows[childWindows.Count - 3], WM_KEYDOWN, ((IntPtr)curKey), (IntPtr)lparam);

            //////Debug.WriteLine("Key Down: " + e.KeyValue);

            //e.Handled = true;
            //e.SuppressKeyPress = true;
        }

        private void keyPressUp(object sender, KeyEventArgs e)
        {
            if (worldComboBox.Focused)
            {
                e.Handled = false;
                return;
            }

            //////////////List<IntPtr> childWindows = GetChildWindows(rsForm.Handle);
            //////////////Debug.WriteLine("Key Up: " + e.KeyValue);
            //////////////int curKey = e.KeyValue;

            //////////////int scanCode = MapVirtualKey(e.KeyCode, 0);
            //////////////int lparam = 0x00000001 | (scanCode << 16) | (1 << 30) | (1 << 31);

            ////////////////SendMessage(childWindows[childWindows.Count - 3], WM_SETFOCUS, (IntPtr)cap, IntPtr.Zero);
            ////////////////PostMessage(childWindows[childWindows.Count - 3], WM_KEYDOWN, ((IntPtr)curKey), (IntPtr)lparam);
            //////////////////PostMessage(childWindows[childWindows.Count - 3], WM_KEYUP, ((IntPtr)curKey), (IntPtr)lparam);

            ////////////////rsForm.clientBrowser.Focus();



            ////////////////PostMessage(childWindows[childWindows.Count - 3], WM_KEYDOWN, ((IntPtr)curKey), (IntPtr)lparam);
            ////////////////PostMessage(childWindows[childWindows.Count - 3], WM_CHAR, ((IntPtr)e.KeyCode), (IntPtr)lparam);
            //////////////SendMessage(childWindows[childWindows.Count - 3], WM_SETFOCUS, (IntPtr)cap, IntPtr.Zero);
            //////////////PostMessage(childWindows[childWindows.Count - 3], WM_KEYUP, ((IntPtr)curKey), (IntPtr)lparam);
            //////////////blowUpPictureBox.Focus();


            //////////////e.Handled = true;
            //////////////e.SuppressKeyPress = true;
        }

        private void blowUpMouseMove(object sender, MouseEventArgs e)
        {

            if (isMouseClick)
            {
                return;
            }

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

            IntPtr lParam = (IntPtr)(((int)(rsForm.Top + mouseScaledY + 31 + mouseYOffset) << 16) | (int)(rsForm.Left + mouseScaledX + 10 + mouseXOffset));

            IntPtr lParamHittest = (IntPtr)(((int)WM_MOUSEMOVE << 16) | HTCLIENT);

            SendMessage(childWindows[childWindows.Count - 1], WM_SETCURSOR, childWindows[childWindows.Count - 1], (IntPtr)lParamHittest);
            PostMessage(childWindows[childWindows.Count - 1], WM_MOUSEMOVE, IntPtr.Zero, lParam);
            SendMessage(childWindows[childWindows.Count - 1], WM_NCHITTEST, IntPtr.Zero, lParam);

            lastMousePosX = (int)mouseScaledX;
            lastMousePosY = (int)mouseScaledY;
            //blowUpPictureBox.Focus();
        }

        private void calibrateVoidLensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            voidLensesPanel.Visible = !voidLensesPanel.Visible;
            if (voidLensesPanel.Visible)
            {
                offsetXTrackBar.Value = mouseXOffset;
                offsetYTrackBar.Value = mouseYOffset;
                mouseClicksTrackBar.Value = mouseClickAmount;

                labelXOffset.Text = mouseXOffset.ToString();
                labelYOffset.Text = mouseYOffset.ToString();
                labelClickAmount.Text = mouseClickAmount.ToString();

            }
        }

        private void offsetXTrackBar_Scroll(object sender, EventArgs e)
        {
            labelXOffset.Text = offsetXTrackBar.Value.ToString();
            mouseXOffset = offsetXTrackBar.Value;
        }

        private void offsetYTrackBar_Scroll(object sender, EventArgs e)
        {
            labelYOffset.Text = offsetYTrackBar.Value.ToString();
            mouseYOffset = offsetYTrackBar.Value;
        }

        private void mouseClicksTrackBar_Scroll(object sender, EventArgs e)
        {
            labelClickAmount.Text = mouseClicksTrackBar.Value.ToString();
            mouseClickAmount = mouseClicksTrackBar.Value;
        }

        private void toggleStretchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isStretched = !isStretched;

            if (isStretched)
            {
                blowUpPictureBox.Left = this.ClientRectangle.Left;
                blowUpPictureBox.Top = menuConfig.Bottom;
                blowUpPictureBox.Width = this.ClientRectangle.Width;
                blowUpPictureBox.Height = this.ClientRectangle.Height - menuConfig.Bottom;
            }
            else
            {
                blowUpPictureBox.Top = menuConfig.Bottom;
                blowUpPictureBox.Height = this.ClientRectangle.Height - menuConfig.Bottom;

                int calcWidth = (int)(blowUpPictureBox.Height * rsRatio);
                blowUpPictureBox.Left = (this.Width / 2) - (calcWidth / 2);
                blowUpPictureBox.Width = calcWidth;
            }
        }

        private void returnFocusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rsForm.returnFocus = !rsForm.returnFocus;
        }

        private void blowUpMouseDown(object sender, MouseEventArgs e)
        {
            Debug.WriteLine("Mouse Down");
            List<IntPtr> childWindows = GetChildWindows(rsForm.Handle);

            float scaleRatioX = (float)blowUpPictureBox.Width / (float)rsForm.clientBrowser.Width;
            float scaleRatioY = (float)blowUpPictureBox.Height / (float)rsForm.clientBrowser.Height;

            float mouseScaledX = ((float)e.X / (float)blowUpPictureBox.Width) * rsForm.clientBrowser.Width;
            float mouseScaledY = ((float)e.Y / (float)blowUpPictureBox.Height) * rsForm.clientBrowser.Height;

            IntPtr lParam = (IntPtr)(((int)(rsForm.Top + mouseScaledY + 31 + mouseYOffset) << 16) | (int)(rsForm.Left + mouseScaledX + 10 + mouseXOffset));

            const int MK_LBUTTON = 0x0001;
            const int MK_RBUTTON = 0x0002;

            isMouseClick = true;

            if (e.Button == MouseButtons.Right)
            {
                //PostMessage(childWindows[childWindows.Count - 1], WM_MOUSEMOVE, (IntPtr)MK_LBUTTON, lParam);
                for (int click = 0; click < mouseClickAmount; ++click)
                {
                    PostMessage(childWindows[childWindows.Count - 1], WM_RBUTTONDOWN, (IntPtr)MK_RBUTTON, lParam);
                }

            }

            if (e.Button == MouseButtons.Left)
            {
                //PostMessage(childWindows[childWindows.Count - 1], WM_MOUSEMOVE, (IntPtr)MK_LBUTTON, lParam);
                for (int click = 0; click < mouseClickAmount; ++click)
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

            IntPtr lParam = (IntPtr)(((int)(rsForm.Top + mouseScaledY + 31 + mouseYOffset) << 16) | (int)(rsForm.Left + mouseScaledX + 10 + mouseXOffset));

            const int MK_LBUTTON = 0x0001;
            const int MK_RBUTTON = 0x0002;

            isMouseClick = false;

            if (e.Button == MouseButtons.Right)
            {
                //PostMessage(childWindows[childWindows.Count - 1], WM_MOUSEMOVE, (IntPtr)MK_LBUTTON, lParam);
                for (int click = 0; click < mouseClickAmount; ++click)
                {
                    PostMessage(childWindows[childWindows.Count - 1], WM_RBUTTONUP, IntPtr.Zero, lParam);
                }

            }

            if (e.Button == MouseButtons.Left)
            {
                //PostMessage(childWindows[childWindows.Count - 1], WM_MOUSEMOVE, (IntPtr)MK_LBUTTON, lParam);
                for (int click = 0; click < mouseClickAmount; ++click)
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


    }


}
