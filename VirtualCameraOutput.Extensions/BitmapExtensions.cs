
using System.Drawing;
using System.Drawing.Imaging;

namespace VirtualCameraOutput.Extensions
{
    public static class BitmapExtensions
    {
        public static byte[] ToArray(this Bitmap bmp)
        {
            Rectangle bmpArea = new Rectangle(0, 0, bmp.Width, bmp.Height);
            var bmpData = bmp.LockBits(bmpArea, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            byte[] data = new byte[bmpData.Stride * bmpData.Height];
            System.Runtime.InteropServices.Marshal.Copy(bmpData.Scan0, data, 0, data.Length);
            bmp.UnlockBits(bmpData);
            var fixedData = data.Reverse();
            return fixedData.ToArray();
        }

    }
}