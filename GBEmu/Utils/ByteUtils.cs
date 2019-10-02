using System.Collections.Generic;
using System.Linq;

namespace GBEmu.Utils
{
    public static class ByteUtils
    {
        public static IEnumerable<byte> HexStringToBytes(string hex) =>
            hex.Chunkify(2)
                .Select(ch => byte.Parse(new string(ch.ToArray()), System.Globalization.NumberStyles.HexNumber));

    }
}
