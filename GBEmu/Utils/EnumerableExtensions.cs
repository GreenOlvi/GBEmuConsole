using System.Collections.Generic;
using System.Linq;

namespace GBEmu.Utils
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<IEnumerable<T>> Chunkify<T>(this IEnumerable<T> input, int chunkSize) =>
            input.Select((e, i) => (e, i))
                .GroupBy(t => t.i / chunkSize)
                .Select(g => g.Select(t => t.e));
    }
}
