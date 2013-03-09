using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OldSchoolScaler
{

    public partial class ClientForm : Form
    {

        public Form1 myOwner;
        int totalWidth = 0;
        bool scrollHandled = false;

        public delegate bool EnumWindowProc(IntPtr hWnd, IntPtr parameter);

        [DllImport("user32")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnumChildWindows(IntPtr window, EnumWindowProc callback, IntPtr i);
        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll")]
        public static extern IntPtr PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        const int WM_MOUSEWHEEL = 0x020A;
        const int WM_SETCURSOR = 0x0020;
        const int WM_NCHITTEST = 0x84;

        protected override void WndProc(ref Message m)
        {
            const int WM_MOUSEWHEEL = 0x020A;
            switch (m.Msg)
            {
                case WM_MOUSEWHEEL:
                    if (m.HWnd == Handle)
                    {

                        if (!scrollHandled)
                        {
                            List<IntPtr> childWindows = GetChildWindows(this.Handle);

                            const int HTCLIENT = 1;

                            //Debug.WriteLine("Normal: X(" + e.X + "), Y(" + e.Y + ")");
                            //Debug.WriteLine("Scaled: X(" + mouseScaledX + "), Y(" + mouseScaledY + ")");

                            IntPtr lParam = (IntPtr)(((int)(this.Top + myOwner.lastMousePosY + 31 + Properties.Settings.Default.yOffsetMouse) << 16) | (int)(this.Left + myOwner.lastMousePosX + 10 + Properties.Settings.Default.xOffsetMouse));

                            IntPtr lParamHittest = (IntPtr)(((int)WM_MOUSEWHEEL << 16) | HTCLIENT);

                            SendMessage(childWindows[childWindows.Count - 1], WM_SETCURSOR, childWindows[childWindows.Count - 1], (IntPtr)lParamHittest);
                            PostMessage(childWindows[childWindows.Count - 1], WM_MOUSEWHEEL, m.WParam, lParam);
                            SendMessage(childWindows[childWindows.Count - 1], WM_NCHITTEST, IntPtr.Zero, lParam);

                            //Debug.WriteLine("Forwarded mouse scroll");
                            scrollHandled = true;
                        }
                        else
                        {
                            scrollHandled = false;
                        }
                                    
                    }
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }

        public ClientForm()
        {
            InitializeComponent();
            this.MouseWheel += new MouseEventHandler(gotMouseWheel);
        }

        public Control getBrowser()
        {
            return clientBrowser;
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

        private void gotFocus(object sender, EventArgs e)
        {
            //if (returnFocus)
            //{
            //    myOwner.Focus();
            //}
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {
            //Offset the form to go into the "void".
            //This is required as right clicks (and sometimes left) do not always get sent if the client is in view.
            foreach (Screen s in Screen.AllScreens)
            {
                totalWidth += s.Bounds.Width;
            }

            this.Left = totalWidth;

            clientBrowser.Navigate("http://oldschool58.runescape.com/", null, null, "Old School Scaler\r\n");

        }

        private void gettingClosed(object sender, FormClosingEventArgs e)
        {
            myOwner.Close();
        }

        private void gotMouseWheel(object sender, MouseEventArgs e)
        {

            //List<IntPtr> childWindows = GetChildWindows(this.Handle);

            //const int HTCLIENT = 1;

            ////Debug.WriteLine("Normal: X(" + e.X + "), Y(" + e.Y + ")");
            ////Debug.WriteLine("Scaled: X(" + mouseScaledX + "), Y(" + mouseScaledY + ")");

            //IntPtr lParam = (IntPtr)(((int)(this.Top + myOwner.lastMousePosY + 31 + Properties.Settings.Default.yOffsetMouse) << 16) | (int)(this.Left + myOwner.lastMousePosX + 10 + Properties.Settings.Default.xOffsetMouse));

            //IntPtr lParamHittest = (IntPtr)(((int)WM_MOUSEWHEEL << 16) | HTCLIENT);

            //SendMessage(childWindows[childWindows.Count - 1], WM_SETCURSOR, childWindows[childWindows.Count - 1], (IntPtr)lParamHittest);
            //PostMessage(childWindows[childWindows.Count - 1], WM_MOUSEWHEEL, IntPtr.Zero, lParam);
            //SendMessage(childWindows[childWindows.Count - 1], WM_NCHITTEST, IntPtr.Zero, lParam);

            //Debug.WriteLine("Did scroll");
        }

    }
}
