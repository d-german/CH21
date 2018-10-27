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
    }
}