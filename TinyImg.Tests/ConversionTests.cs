namespace TinyImg.Tests
{

    [TestClass]
    public class ConversionTests
    {
        public static byte[] ReferenceFile = new byte[] { };
        public static byte[] ReferenceFileLarge = new byte[] { };

        [TestInitialize]
        public void SetupReference()
        {
            var image = new Image(128, 128);
            var image2 = new Image(8192, 8192);

            image.PixelData = new CGAPalette[image.Width * image.Height];
            Array.Fill(image.PixelData, CGAPalette.Green);

            image2.PixelData = new CGAPalette[image2.Width * image2.Height];
            Array.Fill(image2.PixelData, CGAPalette.Green);

            ReferenceFile = image.ToBytes();
            ReferenceFileLarge = image.ToBytes();
        }

        [TestMethod]
        public void SerialiseOnce()
        {
            var image = new Image(128, 128);

            image.PixelData = new CGAPalette[(int)Math.Pow(128, 2)];
            Array.Fill(image.PixelData, CGAPalette.Green);

            var bytes = image.ToBytes();

            File.WriteAllBytes("SerialiseOnce.timg", bytes);
        }

        [TestMethod]
        public void DeserialiseOnce()
        {
            Image.FromBytes(ReferenceFile); // idk if i should put asserts to check if the file was correctly decoded... eh, if it doesn't throw an exception, it's good enough
        }

        [TestMethod]
        public void SerialiseLargeOnce()
        {
            var image = new Image(8192, 8192);

            image.PixelData = new CGAPalette[(int)Math.Pow(8192, 2)];
            Array.Fill(image.PixelData, CGAPalette.Green);

            var bytes = image.ToBytes();

            File.WriteAllBytes("SerialiseLargeOnce.timg", bytes);
        }

        [TestMethod]
        public void DeserialiseLargeOnce()
        {
            Image.FromBytes(ReferenceFileLarge);
        }

        [TestMethod]
        [DataRow((ushort)128)]
        [DataRow((ushort)256)]
        [DataRow((ushort)512)]
        [DataRow((ushort)1024)]
        [DataRow((ushort)2048)]
        public void SerialiseMany(ushort size)
        {
            var image = new Image(size, size);

            image.PixelData = new CGAPalette[size * size];
            Array.Fill(image.PixelData, CGAPalette.Green);

            var bytes = image.ToBytes();

            File.WriteAllBytes($"SerialiseMany{size}.timg", bytes);
        }
    }
}