using System.Diagnostics;
using TinyImg.ImageSharp;
using TinyImg.Lib;
using TinyImg.Lib.ColourFormats;

namespace TinyImg.CommandLine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("WIP");

            var image = new Image(4, 4);

            image.PixelData = new CGAPalette[16];
            Array.Fill(image.PixelData, CGAPalette.Cyan);

            image.ToPNGFile("test.png");
        }
    }
}