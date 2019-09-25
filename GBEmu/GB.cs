namespace GBEmu
{
    public class GB
    {
        public GB(ICartridge cartridge)
        {
            _memory = new MemoryMap(cartridge);
        }

        private readonly Register16 _af = new Register16();
        private readonly Register16 _bc = new Register16();
        private readonly Register16 _de = new Register16();
        private readonly Register16 _hl = new Register16();

        private readonly MemoryMap _memory;

        //8-bit registers
        public byte A { get => _af.Hi; private set => _af.Hi = value; }
        public byte F { get => _af.Lo; private set => _af.Lo = value; }
        public byte B { get => _bc.Hi; private set => _bc.Hi = value; }
        public byte C { get => _bc.Lo; private set => _bc.Lo = value; }
        public byte D { get => _de.Hi; private set => _de.Hi = value; }
        public byte E { get => _de.Lo; private set => _de.Lo = value; }
        public byte H { get => _hl.Hi; private set => _hl.Hi = value; }
        public byte L { get => _hl.Lo; private set => _hl.Lo = value; }

        //16-bit registers
        public ushort AF { get => _af.Value; }
        public ushort BC { get => _bc.Value; }
        public ushort DE { get => _de.Value; }
        public ushort HL { get => _hl.Value; }
        public ushort SP { get; private set; }
        public ushort PC { get; private set; }

        public CpuFlags Flags { get => (CpuFlags)F; }

        public IReadOnlyMemory Memory => _memory;
    }
}
