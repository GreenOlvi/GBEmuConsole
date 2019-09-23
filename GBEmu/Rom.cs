using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace GBEmu
{
    public class Rom : IRom
    {
        public static Rom ReadFromFile(string fileName)
        {
            var bytes = File.ReadAllBytes(fileName);
            return new Rom(bytes);
        }

        public Rom(IEnumerable<byte> bytes)
        {
            _bytes = bytes.ToArray();
        }

        private readonly byte[] _bytes;

        public byte GetByte(int address)
        {
            return _bytes[address];
        }
    }
}
