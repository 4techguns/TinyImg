namespace TinyImg.Tests
{

    [TestClass]
    public class ConversionTests
    {
        public static byte[] ReferenceFile = new byte[] { };

        [TestInitialize]
        public void SetupReference()
        {
            var image = new Image(128, 128);

            image.PixelData = new CGAPalette[(int)Math.Pow(128, 2)];
            Array.Fill(image.PixelData, CGAPalette.Green);

            ReferenceFile = image.ToBytes();
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
    }
}