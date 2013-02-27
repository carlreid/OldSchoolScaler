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

        public Form myOwner;

        public bool returnFocus = false;

        public delegate bool EnumWindowProc(IntPtr hWnd, IntPtr parameter);

        [DllImport("user32")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnumChildWindows(IntPtr window, EnumWindowProc callback, IntPtr i);

        public ClientForm()
        {
            InitializeComponent();
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
            if (returnFocus)
            {
                myOwner.Focus();
            }
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {
            this.Left = 9000;
            this.Top = 9000;
            //this.ClientSize = new Size(0,0);

            clientBrowser.Navigate("http://oldschool.runescape.com/", null, null, "Old School Scaler\r\n");

        }

        private void gettingClosed(object sender, FormClosingEventArgs e)
        {
            myOwner.Close();
        }

    }
}
