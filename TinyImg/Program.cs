using System.Diagnostics;
using TinyImg.Lib;
using TinyImg.Lib.ColourFormats;

namespace TinyImg
{
    internal class Program
    {
        // test code, might be nuked later
        static void Main(string[] args)
        {
            // why didn't i just use unit tests?
            var image = new Image(240, 160);

            image.PixelData = new CGAPalette[image.Width * image.Height];

            Array.Fill(image.PixelData, CGAPalette.LightGreen, 0, image.Width * image.Height);

            byte[] imageBytes = image.ToBytes();

            File.WriteAllBytes("image.timg", imageBytes);

            Console.WriteLine($"Converted size: {imageBytes.Length} bytes");

            // why in the absolute hell did i do this
            // var file = File.ReadAllBytes("image.timg");

            // test if converting from a byte array is okay
            var img2 = Image.FromBytes(imageBytes);

            // would it even be necessary to print the magic string? decode function always throws an exception if the magic isn't TIMG
            Console.WriteLine($"INFO - {img2.Magic} v{img2.FileRevisionMajor} {img2.Width}x{img2.Height}");
        }
    }
}