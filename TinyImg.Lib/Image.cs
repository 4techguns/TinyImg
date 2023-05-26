using System.Diagnostics;
using System.Text;
using TinyImg.Lib.ColourFormats;

namespace TinyImg.Lib
{
    public class Image
    {
        /// <summary>
        /// First 4 bytes of the file that states its format.
        /// Must always be "TIMG", otherwise assume a different format and fail to decode.
        /// </summary>
        public string Magic { get; set; }

        /// <summary>
        /// Revision of the file format.
        /// </summary>
        public byte FileRevisionMajor { get; set; }

        /// <summary>
        /// Width of the image.
        /// </summary>
        public ushort Width { get; set; }

        /// <summary>
        /// Height of the image.
        /// </summary>
        public ushort Height { get; set; }

        /// <summary>
        /// Array of RGBA pixel data.
        /// </summary>
        public CGAPalette[] PixelData { get; set; }

        public Image(ushort width, ushort height)
        {
            Magic = "TIMG";
            FileRevisionMajor = 0x01;
            Width = width;
            Height = height;
            PixelData = new CGAPalette[] { };
        }

        public Image(string magic, byte revision, ushort width, ushort height, CGAPalette[] data)
        {
            Magic = magic;
            FileRevisionMajor = revision;
            Width = width;
            Height = height;
            PixelData = data;
        }

        public byte[] ToBytes()
        {
            byte[] magic = Encoding.ASCII.GetBytes(Magic);
            byte[] width = BitConverter.GetBytes(Width);
            byte[] height = BitConverter.GetBytes(Height);
            byte[] pixels = PixelData
                .ToList()
                .Cast<byte>()
                .ToArray(); 

            byte[] final = Array.Empty<byte>();

            final = final
                .Concat(magic)
                .Concat(new[] { FileRevisionMajor })
                .Concat(width)
                .Concat(height)
                .Concat(pixels)
                .ToArray();

            return final;
        }

        public static Image FromBytes(byte[] input)
        {
            Debug.WriteLine("--------------------------");

            var list = input.ToList();

            var magic = Encoding.ASCII.GetString(list.Take(4).ToArray());
            var revision = list.Skip(4).Take(1).ToArray()[0];
            var width = BitConverter.ToUInt16(list.Skip(5).Take(2).ToArray());
            var height = BitConverter.ToUInt16(list.Skip(7).Take(2).ToArray());
            var data = list.Skip(9)
                    .Cast<CGAPalette>()
                    .ToArray();

            if (magic != "TIMG") 
                throw new InvalidOperationException($"Magic string is invalid. Expected TIMG; got {magic}");

            return new Image(
                magic: magic,
                revision: revision,
                width: width,
                height: height,
                data: data
            );
        }
    }
}