using System;
using System.Drawing;
using VirtualCameraOutput;
namespace TestImageOutput
{
    class Program
    {
        static void Main(string[] args)
        {
            Bitmap image = new Bitmap("FLAG_B24.BMP");
            VirtualOutput virtualOutput = new VirtualOutput(image.Width, image.Height, 20, FourCC.FOURCC_24BG);
            ImageConverter converter = new ImageConverter();
            byte[] imageBytes = (byte[])converter.ConvertTo(image, typeof(byte[]));
            while (true)
                virtualOutput.Send(imageBytes);
        }
    }
}
