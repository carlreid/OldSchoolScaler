using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace OldSchoolScaler
{

    //From: http://stackoverflow.com/questions/2434156/webbrowser-drawtobitmap-or-other-methods/2434231#2434231

    public static class Utilities
    {

        public static Image CaptureScreen()
        {
            return CaptureWindow(User32.GetDesktopWindow());
        }

        public static Image CaptureWindow(IntPtr handle)
        {

            IntPtr hdcSrc = User32.GetWindowDC(handle);

            User32.RECT windowRect = new User32.RECT();
            User32.GetWindowRect(handle, ref windowRect);

            int width = windowRect.right - windowRect.left;
            int height = windowRect.bottom - windowRect.top;

            IntPtr hdcDest = Gdi32.CreateCompatibleDC(hdcSrc);
            IntPtr hBitmap = Gdi32.CreateCompatibleBitmap(hdcSrc, width, height);

            IntPtr hOld = Gdi32.SelectObject(hdcDest, hBitmap);
            Gdi32.BitBlt(hdcDest, 0, 0, width, height, hdcSrc, 0, 0, 13369376);
            Gdi32.SelectObject(hdcDest, hOld);
            Gdi32.DeleteDC(hdcDest);
            User32.ReleaseDC(handle, hdcSrc);

            Image image = Image.FromHbitmap(hBitmap);

            Gdi32.DeleteObject(hBitmap);

            return image;
        }
    }
}
