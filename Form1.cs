﻿using System;
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
        //const int WM_PARENTNOTIFY = 0x0210;
        //const int WM_MOUSEACTIVATE = 0x0021;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            rsForm = new ClientForm();
            rsForm.myOwner = this;
            rsForm.Show();


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (blowUpPictureBox.Image != null)
            {
                blowUpPictureBox.Image.Dispose();
            }
            blowUpPictureBox.Image = ControlExtensions.DrawToImage(rsForm.clientBrowser);
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
            List<IntPtr> childWindows = GetChildWindows(rsForm.Handle);

            int curKey = e.KeyValue;

            int scanCode = MapVirtualKey(e.KeyCode, 0);
            int lparam = 0x00000001 | (scanCode << 16);

            SendMessage(childWindows[childWindows.Count - 3], WM_SETFOCUS, (IntPtr)cap, IntPtr.Zero);
            PostMessage(childWindows[childWindows.Count - 3], WM_KEYDOWN, ((IntPtr)curKey), (IntPtr)lparam);
            //PostMessage(childWindows[childWindows.Count - 3], WM_KEYUP, ((IntPtr)curKey), (IntPtr)lparam);

            this.Focus();
        }


        private void gotCLicked(object sender, EventArgs e)
        {
            MouseEventArgs me = e as MouseEventArgs;

            List<IntPtr> childWindows = GetChildWindows(rsForm.Handle);

            //IntPtr lParam = (IntPtr)((826 << 16) | 1171); //Hard Coded to mute RS

            float scaleRatioX = (float)blowUpPictureBox.Width / (float)rsForm.clientBrowser.Width;
            float scaleRatioY = (float)blowUpPictureBox.Height / (float)rsForm.clientBrowser.Height;

            float mouseScaledX = ((float)me.X / (float)blowUpPictureBox.Width) * rsForm.clientBrowser.Width;
            float mouseScaledY = ((float)me.Y / (float)blowUpPictureBox.Height) * rsForm.clientBrowser.Height;

            IntPtr lParam = (IntPtr)(((int)(rsForm.Top + mouseScaledY + 31) << 16) | (int)(rsForm.Left + mouseScaledX + 10));

            const int MK_LBUTTON = 0x0001;

            if (me.Button == MouseButtons.Right)
            {
                PostMessage(childWindows[childWindows.Count - 1], WM_MOUSEMOVE, (IntPtr)MK_LBUTTON, lParam);
                PostMessage(childWindows[childWindows.Count - 1], WM_RBUTTONDOWN, (IntPtr)MK_LBUTTON, lParam);
                PostMessage(childWindows[childWindows.Count - 1], WM_RBUTTONDOWN, (IntPtr)MK_LBUTTON, lParam);
                PostMessage(childWindows[childWindows.Count - 1], WM_RBUTTONUP, IntPtr.Zero, lParam);
            }

            if (me.Button == MouseButtons.Left)
            {
                PostMessage(childWindows[childWindows.Count - 1], WM_MOUSEMOVE, (IntPtr)MK_LBUTTON, lParam);
                PostMessage(childWindows[childWindows.Count - 1], WM_LBUTTONDOWN, (IntPtr)MK_LBUTTON, lParam);
                PostMessage(childWindows[childWindows.Count - 1], WM_LBUTTONDOWN, (IntPtr)MK_LBUTTON, lParam);
                PostMessage(childWindows[childWindows.Count - 1], WM_LBUTTONUP, IntPtr.Zero, lParam);
            }

        }
    }


}
