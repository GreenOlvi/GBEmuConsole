using GBEmu;
using GBEmu.Cartridge;
using System;
using System.Text;

namespace GBEmuConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            ICartridge cart;
            if (args.Length > 0)
            {
                cart = new Cartridge(Rom.ReadFromFile(args[0]));
            }
            else
            {
                cart = new EmptyCartridge();
            }

            var gb = new GB(cart);

            PrintCPU(gb);
            PrintMemory(gb.Memory);
            Console.ReadLine();
        }

        private static void PrintCPU(GB gb)
        {
            Console.WriteLine("A  F");
            Console.WriteLine($"{gb.A:x2} {FlagsString(gb.Flags)}");
            Console.WriteLine("B  C");
            Console.WriteLine($"{gb.B:x2} {gb.C:x2}");
            Console.WriteLine("D  E");
            Console.WriteLine($"{gb.D:x2} {gb.E:x2}");
            Console.WriteLine("H  L");
            Console.WriteLine($"{gb.H:x2} {gb.L:x2}");
            Console.WriteLine();
            Console.WriteLine("SP");
            Console.WriteLine($"{gb.SP:x4}");
            Console.WriteLine("PC");
            Console.WriteLine($"{gb.PC:x4}");
            Console.WriteLine();
        }

        private static void PrintMemory(IReadOnlyMemory memory)
        {
            var sb = new StringBuilder();
            for (uint i = 0; i < 16; i++)
            {
                sb.AppendFormat("{0:x2}", memory.GetByte(i));
                sb.Append(" ");
            }
            Console.WriteLine(sb.ToString());
        }

        private static string FlagsString(CpuFlags flags)
        {
            return new StringBuilder()
                .Append(flags.HasFlag(CpuFlags.Zero) ? 'Z' : ' ')
                .Append(flags.HasFlag(CpuFlags.Sub) ? 'N' : ' ')
                .Append(flags.HasFlag(CpuFlags.HalfCarry) ? 'H' : ' ')
                .Append(flags.HasFlag(CpuFlags.Carry) ? 'C' : ' ')
                .ToString();
        }
    }
}
