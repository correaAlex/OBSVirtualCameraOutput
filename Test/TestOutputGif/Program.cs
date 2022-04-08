using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Gif;
using SixLabors.ImageSharp.PixelFormats;
using System;
using System.IO;
using System.Linq;
using System.Threading;
using VirtualCameraOutput;
namespace TestOutputGif
{
    class Program
    {
        static void Main(string[] args)
        {
            Image gif = Image.Load<Rgb24>("example.gif", new GifDecoder());
            VirtualOutput virtualOutput = new VirtualOutput(gif.Width, gif.Height, 20, FourCC.FOURCC_24BG);
            var frames = gif.Frames.Cast<ImageFrame<Rgb24>>();
            int currentFrame = 0;
            int frameCount = frames.Count();
            while (currentFrame < frameCount)
            {
                var bytes = GetBytesFromFrame(frames.ElementAt(currentFrame));
                virtualOutput.Send(bytes);
                currentFrame = currentFrame + 1 < frameCount ? currentFrame + 1 : 0;
            }
        }
        static byte[] GetBytesFromFrame(ImageFrame<Rgb24> imageFrame)
        {
            using var image = new Image<Rgb24>(imageFrame.Width, imageFrame.Height);
            for (var y = 0; y < image.Height; y++)
            {
                for (var x = 0; x < image.Width; x++)
                {
                    image[x, y] = imageFrame[x, y];
                }
            }

            var memoryStream = new MemoryStream();
            image.SaveAsBmp(memoryStream);
            return memoryStream.ToArray();
        }
    }
}
