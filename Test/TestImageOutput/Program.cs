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
            while (true)
                virtualOutput.Send(image);
        }
    }
}
