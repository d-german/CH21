using System;
using System.Collections.Generic;

namespace CH21Tests
{
    public static class HashHelpers
    {
        /// <summary>
        /// Inserts using custom hash function
        /// </summary>
        /// <param name="keys"></param>
        /// <param name="key"></param>
        /// <typeparam name="T"></typeparam>
        public static void Insert<T>(this IList<T> keys, T key)
        {
            // if position is taken it is overwritten, and is called a collision
            keys[Math.Abs(key.GetHashCode()) % keys.Count] = key;
        }

        /// <summary>
        /// Retrieves using custom hash function
        /// </summary>
        /// <param name="keys"></param>
        /// <param name="key"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Retrieve<T>(this IList<T> keys, T key)
        {
            return keys[Math.Abs(key.GetHashCode()) % keys.Count];
        }
    }
}
