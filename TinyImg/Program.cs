using System.Diagnostics;
using TinyImg.Lib;
using TinyImg.Lib.ColourFormats;

namespace TinyImg
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var image = new Image(240, 160);

            image.PixelData = new CGAPalette[image.Width * image.Height];

            Array.Fill(image.PixelData, CGAPalette.LightGreen, 0, image.Width * image.Height);


            byte[] imageBytes = image.ToBytes();

            File.WriteAllBytes("image.timg", imageBytes);

            Console.WriteLine($"Converted {imageBytes.Length} bytes");

            Console.WriteLine($"Running 150 conversions...");

            var stopwatch = new Stopwatch();

            stopwatch.Start();

            for (int i = 0; i < 151; i++)
            {
                Console.Write($"{i}\r");
                image.ToBytes();
            }

            stopwatch.Stop();

            Console.WriteLine("Done      ");
            Console.WriteLine($"Time: {stopwatch.Elapsed.TotalSeconds} s");
            Console.WriteLine($"{150 / stopwatch.Elapsed.TotalSeconds} conversions/s");

            var file = File.ReadAllBytes("image.timg");

            var img2 = Image.FromBytes(file);

            Console.WriteLine("Converted back");
            Console.WriteLine($"{img2.Magic} v{img2.FileRevisionMajor} {img2.Width}x{img2.Height}");
        }
    }
}