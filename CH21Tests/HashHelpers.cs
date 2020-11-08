using System;
using System.Collections.Generic;

namespace CH21Tests
{
    public static class HashHelpers
    {
        private static int HashToIndex<T>(T val, int arraySize)
        {
            var index = Math.Abs(val.GetHashCode()) % arraySize;
            Console.WriteLine($"Inserting {val} at position {index}");
            return index;
        }

        public static void Insert<T>(this IList<T> items, T item)
        {
            items[HashToIndex(item, items.Count)] = item;
        }
    }
}