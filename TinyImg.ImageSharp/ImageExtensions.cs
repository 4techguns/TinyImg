using SixLabors.ImageSharp;
using TinyImg.Lib;

using Image = TinyImg.Lib.Image;
using ISImage = SixLabors.ImageSharp.Image;

namespace TinyImg.ImageSharp
{
    public static class ImageExtensions
    {
        public static void ToPNGFile(this Image img, string path)
        {
            using (Image<Rgba32> newImg = new(img.Width, img.Height))
            {
                newImg.ProcessPixelRows((rows) =>
                {
                    for (int r = 0; r < img.Height; r++)
                    {
                        var row = rows.GetRowSpan(r);
                        var pixels = img.PixelData
                            .Skip(r * img.Width)
                            .Take(img.Width)
                            .ToArray();
                        
                        for (int c = 0; c < img.Width; c++)
                        {
                            var originalPixel = pixels[c];
                            var convertedPixel = row[c];

                            convertedPixel = MappingTables.CGA[(byte)originalPixel];
                        }
                    }
                });

                newImg.SaveAsPng(path);
            }
        }
    }
}