using System;
using System.Collections;
using System.Collections.Generic;

namespace GBEmu.Cartridge
{
    public class Cartridge : ICartridge
    {
        public Cartridge(IReadOnlyMemory rom)
        {
            _rom = rom;
        }

        private IReadOnlyMemory _rom;

        public byte GetByte(uint address)
        {
            if (address <= 0x7fff)
            {
                return _rom.GetByte(address);
            }

            throw new InvalidOperationException("Trying to read invalid address from cartridge");
        }

        public void SetByte(uint address, byte value)
        {
            throw new InvalidOperationException("Trying to write to read only cartridge");
        }

        public IEnumerator<byte> GetEnumerator() => _rom.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)_rom).GetEnumerator();
    }
}
