using System;
using System.Collections;
using System.Collections.Generic;

namespace GBEmu
{
    public class MemoryMap : IRandomAccessMemory
    {
        public MemoryMap(ICartridge cartridge)
        {
            _cartridge = cartridge;
        }

        private ICartridge _cartridge;

        public byte GetByte(uint address)
        {
            //32kB Cartridge ROM
            if (address <= 0x7fff)
            {
                return _cartridge.GetByte(address);
            }
            
            throw new NotImplementedException();
        }

        public void SetByte(uint address, byte value)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<byte> GetEnumerator()
        {
            return _cartridge.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)_cartridge).GetEnumerator();
        }
    }
}
