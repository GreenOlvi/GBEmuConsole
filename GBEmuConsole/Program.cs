using GBEmu;
using System;
using System.Text;

namespace GBEmuConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var gb = new GB();

            PrintCPU(gb);
            Console.ReadLine();
        }

        private static void PrintCPU(GB gb)
        {
            Console.WriteLine("A  F");
            Console.WriteLine($"{gb.A:x2} {FlagsString(gb.Flags)}");
            Console.WriteLine("B  C");
            Console.WriteLine($"{gb.B:x2} {gb.C:x2}");
        }

        private static string FlagsString(CpuFlags flags)
        {
            var sb = new StringBuilder()
                .Append(flags.HasFlag(CpuFlags.Zero) ? 'Z' : ' ')
                .Append(flags.HasFlag(CpuFlags.Sub) ? 'N' : ' ')
                .Append(flags.HasFlag(CpuFlags.HalfCarry) ? 'H' : ' ')
                .Append(flags.HasFlag(CpuFlags.Carry) ? 'C' : ' ');

            return sb.ToString();
        }
    }
}
