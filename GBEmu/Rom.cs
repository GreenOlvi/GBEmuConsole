using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Collections;

namespace GBEmu
{
    public class Rom : IReadOnlyMemory
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

        public byte GetByte(uint address) => _bytes[address];

        public IEnumerator<byte> GetEnumerator() => ((IEnumerable<byte>)_bytes).GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => _bytes.GetEnumerator();
    }
}
