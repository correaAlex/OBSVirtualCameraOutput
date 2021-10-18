using System;
using System.Drawing;
using System.Drawing.Imaging;
using VirtualCameraOutput;
namespace TestOutputGif
{
    class Program
    {
        static void Main(string[] args)
        {
            Bitmap gif = new Bitmap("example.gif");
            VirtualOutput virtualOutput = new VirtualOutput(gif.Width, gif.Height, 20, FourCC.FOURCC_24BG);
            int currentFrame = 0;
            int frameCount = gif.GetFrameCount(FrameDimension.Time);
            while(currentFrame < frameCount)
            {
                gif.SelectActiveFrame(FrameDimension.Time, currentFrame);
                virtualOutput.Send(gif);
                currentFrame = currentFrame + 1 < frameCount ? currentFrame + 1 : 0;
            }
        }
    }
}
