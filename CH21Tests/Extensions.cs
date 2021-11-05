using System;
using System.Collections.Generic;
using System.Linq;

namespace CH21Tests
{
    internal static class Extensions
    {
        // extension method that displays all elements separated by spaces
        public static string Dump<T>(this IEnumerable<T> data)
        {
            return string.Join(" ", data);
        }

        public static IEnumerable<T> Display<T>(this IEnumerable<T> data, Func<T, T> func = null)
        {
            func ??= i => i;
            Console.WriteLine("=====Start=====");
            foreach (var item in data)
            {
                Console.WriteLine(func(item));
            }

            Console.WriteLine("=====Stop=====");
            return data;
        }

        public static T DisplayItem<T>(this T item, Func<T, T> func = null)
        {
            func ??= i => i;
            Console.WriteLine("=====Start=====");
            Console.WriteLine(func(item));
            Console.WriteLine("=====Stop=====");
            return item;
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

        public static IEnumerable<T> TakeEager<T>(this IEnumerable<T> items, int count)
        {
            var results = new List<T>();
            var index = 0;
            foreach (var item in items)
            {
                Console.WriteLine($"{nameof(TakeEager)} {item}");
                results.Add(item);
                if (++index == count) break;
            }

            return results;
        }

        public static IEnumerable<T> TakeLazy<T>(this IEnumerable<T> items, int count)
        {
            var index = 0;
            foreach (var item in items)
            {
                Console.WriteLine($"{nameof(TakeLazy)} {item}");
                yield return item;
                if (++index == count) yield break;
            }
        }
    }
}
