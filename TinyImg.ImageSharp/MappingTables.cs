using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyImg.ImageSharp
{
    public static class MappingTables
    {
        public static Dictionary<byte, Rgba32> CGA = new Dictionary<byte, Rgba32>
        {
            { 0x00, Rgba32.ParseHex("#000000") },
            { 0x01, Rgba32.ParseHex("#0000AA") },
            { 0x02, Rgba32.ParseHex("#00AA00") },
            { 0x03, Rgba32.ParseHex("#00AAAA") },
            { 0x04, Rgba32.ParseHex("#AA0000") },
            { 0x05, Rgba32.ParseHex("#AA00AA") },
            { 0x06, Rgba32.ParseHex("#AA5500") },
            { 0x07, Rgba32.ParseHex("#AAAAAA") },

            { 0x08, Rgba32.ParseHex("#555555") },
            { 0x09, Rgba32.ParseHex("#5555FF") },
            { 0x0A, Rgba32.ParseHex("#55FF55") },
            { 0x0B, Rgba32.ParseHex("#55FFFF") },
            { 0x0C, Rgba32.ParseHex("#FF5555") },
            { 0x0D, Rgba32.ParseHex("#FF55FF") }, 
            { 0x0E, Rgba32.ParseHex("#FFFF55") },
            { 0x0F, Rgba32.ParseHex("#FFFFFF") },
            { 0x10, Rgba32.ParseHex("#000000") },
        };
    }
}
