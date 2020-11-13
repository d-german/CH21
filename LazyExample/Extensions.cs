using System;
using System.Collections.Generic;

namespace LazyExample
{
    public static class Extensions
    {
        public static IEnumerable<int> GetRangeEager(int begin, int end)
        {
            var items = new List<int>();

            for (var i = begin; i < end; i++)
            {
                Console.WriteLine($"{nameof(GetRangeEager)} {i}");
                items.Add(i);
            }

            return items;
        }

        public static IEnumerable<int> GetRangeLazy(int begin, int end)
        {
            for (var i = begin; i < end; i++)
            {
                Console.WriteLine($"{nameof(GetRangeLazy)} {i}");
                yield return i;
            }
        }

        public static IEnumerable<int> FilterEager(this IEnumerable<int> items, Func<int, bool> predicate)
        {
            var results = new List<int>();

            foreach (var item in items)
            {
                if (predicate(item))
                {
                    Console.WriteLine($"{nameof(FilterEager)} {item}");
                    results.Add(item);
                }
            }

            return results;
        }

        public static IEnumerable<int> FilterLazy(this IEnumerable<int> items, Func<int, bool> predicate)
        {
            foreach (var item in items)
            {
                if (predicate(item))
                {
                    Console.WriteLine($"{nameof(FilterLazy)} {item}");
                    yield return item;
                }
            }
        }
    }
}
