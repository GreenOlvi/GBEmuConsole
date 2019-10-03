using System.Collections.Generic;
using System.Linq;

namespace GBEmu.Utils
{
    public static class ByteUtils
    {
        public static IEnumerable<byte> HexStringToBytes(string hex) =>
            hex.Chunkify(2)
                .Select(ch => byte.Parse(new string(ch.ToArray()), System.Globalization.NumberStyles.HexNumber));

        public static string BytesToHexString(IEnumerable<byte> bytes) =>
            bytes.Select(b => b.ToString("x2"))
                .Aggregate(string.Empty, (a, b) => a + b);
    }
}
