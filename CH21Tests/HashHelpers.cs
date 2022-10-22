using System;
using System.Collections.Generic;

namespace CH21Tests
{
    public static class HashHelpers
    {
        private static int HashFunction<T>(int hashSize, T value)
        {
            return Math.Abs(value.GetHashCode()) % hashSize;
        }

        public static void Insert<T>(this IList<T> values, T value)
        {
            // if position is taken it is overwritten, and is called a collision
            var position = HashFunction(values.Count, value);
            values[position] = value;
        }

        public static T Retrieve<T>(this IList<T> values, T value)
        {
            var position = HashFunction(values.Count, value);
            return values[position];
        }
    }
}
