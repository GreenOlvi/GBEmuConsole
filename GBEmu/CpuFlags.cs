using System;

namespace GBEmu
{
    [Flags]
    public enum CpuFlags : byte
    {
        Zero = 0x80,
        Sub = 0x40,
        HalfCarry = 0x20,
        Carry = 0x10,
    }
}
