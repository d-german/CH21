﻿using System;
using System.Collections.Generic;

namespace CH21Tests
{
    public static class HashHelpers
    {
        /// <summary>
        /// Inserts using custom hash function
        /// </summary>
        /// <param name="items"></param>
        /// <param name="item"></param>
        /// <typeparam name="T"></typeparam>
        public static void Insert<T>(this IList<T> items, T item)
        {
            var index = Math.Abs(item.GetHashCode()) % items.Count;
            items[index] = item;
        }

        /// <summary>
        /// Retrieves using custom hash function
        /// </summary>
        /// <param name="items"></param>
        /// <param name="item"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Retrieve<T>(this IList<T> items, T item)
        {
            return items[Math.Abs(item.GetHashCode()) % items.Count];
        }
    }
}
