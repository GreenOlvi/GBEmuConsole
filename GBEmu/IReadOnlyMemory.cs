using System.Collections.Generic;

namespace GBEmu
{
    public interface IReadOnlyMemory : IEnumerable<byte>
    {
        byte GetByte(uint address);
    }
}
