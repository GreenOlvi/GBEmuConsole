using System;
using System.Collections.Generic;
using System.Linq;

namespace GBEmu.Utils
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<IEnumerable<T>> Chunkify<T>(this IEnumerable<T> input, int chunkSize)
        {
            if (chunkSize <= 0)
            {
                throw new ArgumentException("Chunk size should be larger than 0");
            }

            return input.Select((e, i) => (e, i))
                .GroupBy(t => t.i / chunkSize)
                .Select(g => g.Select(t => t.e));

        }
    }
}
