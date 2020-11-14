using System;
using System.Collections.Generic;

namespace CH21Tests
{
    internal static class Extensions
    {
        // extension method that displays all elements separated by spaces
        public static string Display<T>(this IEnumerable<T> data)
        {
            return string.Join(" ", data);
        }

        public static IEnumerable<int> GetInts()
        {
            Console.WriteLine(5);
            yield return 5;
            Console.WriteLine(4);
            yield return 4;
            Console.WriteLine(3);
            yield return 3;
            Console.WriteLine(2);
            yield return 2;
            Console.WriteLine(1);
            yield return 1;
            Console.WriteLine(0);
            yield return 0;
        }

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

        public static IEnumerable<T> FilterEager<T>(this IEnumerable<T> items, Func<T, bool> predicate)
        {
            var results = new List<T>();

            foreach (var item in items)
            {
                if (!predicate(item)) continue;

                Console.WriteLine($"{nameof(FilterEager)} {item}");
                results.Add(item);
            }

            return results;
        }

        public static IEnumerable<T> FilterLazy<T>(this IEnumerable<T> items, Func<T, bool> predicate)
        {
            foreach (var item in items)
            {
                if (!predicate(item)) continue;

                Console.WriteLine($"{nameof(FilterLazy)} {item}");
                yield return item;
            }
        }
    }
}
