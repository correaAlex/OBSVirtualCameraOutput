# OBSVirtualCameraOutput
Sends frames to a OBS Virtual Camera from .NET

## Getting started
### *Step 1: Install [libyuv](https://vcpkg.info/port/libyuv)*
```sh
  .\vcpkg install libyuv
```
### *Step 2: Add VirtualOutput to dependencies in your project*
## Usage
```csharp
Bitmap image = new Bitmap(640, 480);
Random rnd = new Random();
VirtualOutput virtualOutput = new VirtualOutput(image.Width, image.Height, 20, FourCC.FOURCC_24BG);
ImageConverter converter = new ImageConverter();
while (true)
{
  for (var x = 0; x < image.Width; x++)
  {
    for (var y = 0; y < image.Height; y++)
    {
      Color randomColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
      image.SetPixel(x, y, randomColor);
    }
  }
  byte[] imageBytes = (byte[])converter.ConvertTo(image, typeof(byte[]));
  virtualOutput.Send(imageBytes);
}
```
For more examples check out the [Examples](https://github.com/correaAlex/OBSVirtualCameraOutput/tree/master/Test) folder

![Example](https://i.ibb.co/6D35WS8/image.png)
