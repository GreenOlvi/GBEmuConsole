using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GBEmu.Cartridge
{
    public class EmptyCartridge : ICartridge
    {
        private static IEnumerable<byte> _emptyRom = Enumerable.Repeat((byte)0x00, 0x8000);

        public byte GetByte(uint address)
        {
            return 0;
        }

        public void SetByte(uint address, byte value)
        {
        }

        public IEnumerator<byte> GetEnumerator() => _emptyRom.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)_emptyRom).GetEnumerator();
    }
}
