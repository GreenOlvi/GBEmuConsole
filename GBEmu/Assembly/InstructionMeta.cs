using System;
using System.Collections.Generic;
using System.Text;

namespace GBEmu.Assembly
{
    public class InstructionMeta
    {
        public InstructionMeta(string name, int length, params byte[] opcodes)
        {
            Name = name;
            Length = length;
            Opcodes = opcodes;
        }

        public string Name { get; }
        public int Length { get; }
        public byte[] Opcodes { get; }
    }
}
