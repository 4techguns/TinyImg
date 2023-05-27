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
            { 0x00, Rgba32.ParseHex("000000FF") },
            { 0x01, Rgba32.ParseHex("0000AAFF") },
            { 0x02, Rgba32.ParseHex("00AA00FF") },
            { 0x03, Rgba32.ParseHex("00AAAAFF") },
            { 0x04, Rgba32.ParseHex("AA0000FF") },
            { 0x05, Rgba32.ParseHex("AA00AAFF") },
            { 0x06, Rgba32.ParseHex("AA5500FF") },
            { 0x07, Rgba32.ParseHex("AAAAAAFF") },

            { 0x08, Rgba32.ParseHex("555555FF") },
            { 0x09, Rgba32.ParseHex("5555FFFF") },
            { 0x0A, Rgba32.ParseHex("55FF55FF") },
            { 0x0B, Rgba32.ParseHex("55FFFFFF") },
            { 0x0C, Rgba32.ParseHex("FF5555FF") },
            { 0x0D, Rgba32.ParseHex("FF55FFFF") }, 
            { 0x0E, Rgba32.ParseHex("FFFF55FF") },
            { 0x0F, Rgba32.ParseHex("FFFFFFFF") },
            { 0x10, Rgba32.ParseHex("000000FF") },
        };
    }
}
