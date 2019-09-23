namespace GBEmu
{
    public class Register16
    {
        public byte Hi;
        public byte Lo;

        public ushort Value
        {
            get => (ushort)((Hi << 8) | Lo);
            set
            {
                Hi = (byte)(value >> 8 & 0xff);
                Lo = (byte)(value & 0xff);
            }
        }
    }
}
