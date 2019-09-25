namespace GBEmu
{
    public interface IRandomAccessMemory : IReadOnlyMemory
    {
        void SetByte(uint address, byte value);
    }
}
