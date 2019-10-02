using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace GBEmu.Assembly
{
    public static class Instructions
    {
        public static InstructionMeta NOP = new InstructionMeta("NOP", 1, 0x00);
        public static InstructionMeta STOP = new InstructionMeta("STOP", 2, 0x10);

        public static InstructionMeta LD_r_u8 = new InstructionMeta("LD r, u8", 2, 0x06, 0x0e, 0x16, 0x1e, 0x26, 0x2e);
        public static InstructionMeta LD_mHL_u8 = new InstructionMeta("LD (HL), u8", 2, 0x36);
        public static InstructionMeta LD_r_r = new InstructionMeta("LD r, r", 1,
            0x7f,                                // A, A
            0x78, 0x79, 0x7a, 0x7b, 0x7c, 0x7d,  // A, r
            0x40, 0x41, 0x42, 0x43, 0x44, 0x45,  // B, r
            0x48, 0x49, 0x4a, 0x4b, 0x4c, 0x4d,  // C, r
            0x50, 0x51, 0x52, 0x53, 0x54, 0x55,  // D, r
            0x58, 0x59, 0x5a, 0x5b, 0x5c, 0x5d,  // E, r
            0x60, 0x61, 0x62, 0x63, 0x64, 0x65,  // H, r
            0x68, 0x69, 0x6a, 0x6b, 0x6c, 0x6d); // L, r
        public static InstructionMeta LD_r_mHL = new InstructionMeta("LD r, (HL)", 1, 0x7e, 0x46, 0x4e, 0x56, 0x5e, 0x66, 0x6e);
        public static InstructionMeta LD_mHL_r = new InstructionMeta("LD (HL), r", 1, 0x70, 0x71, 0x72, 0x73, 0x74, 0x75);
        public static InstructionMeta LD_A_mBC = new InstructionMeta("LD A, (BC)", 1, 0x0a);
        public static InstructionMeta LD_A_mDE = new InstructionMeta("LD A, (DE)", 1, 0x1a);
        public static InstructionMeta LD_A_m16 = new InstructionMeta("LD A, (u16)", 3, 0xfa);
        public static InstructionMeta LD_A_u8 = new InstructionMeta("LD A, u8", 2, 0x3e);

        static Instructions()
        {
            var allMeta = typeof(Instructions).GetFields(BindingFlags.Static | BindingFlags.Public)
                .Where(m => m.FieldType == typeof(InstructionMeta))
                .Select(m => (InstructionMeta)m.GetValue(null));

            InstructionLength = allMeta.SelectMany(m => m.Opcodes.Select(o => (o, m)))
                .ToDictionary(t => t.o, t => t.m.Length);
        }

        public static Dictionary<byte, int> InstructionLength;
    }
}
