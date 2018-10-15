using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CH21Tests
{
    [TestClass]
    public class CH21_8Tests
    {
        public delegate bool NumberPredicate(int number);

        private int[] _numbers = new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};

        private List<int> FilterArray(IEnumerable<int> array, NumberPredicate predicate)
        {
            var result = new List<int>();
            foreach (var num in array)
            {
                if (predicate(num)) result.Add(num);
            }

            return result;
        }

        private List<int> FilterArray(IEnumerable<int> array, Func<int, bool> predicate)
        {
            var result = new List<int>();
            foreach (var num in array)
            {
                if (predicate(num)) result.Add(num);
            }

            return result;
        }


        NumberPredicate _evenPredicate = number => number % 2 == 0;

        [TestMethod]
        public void TestMethod1()
        {
            var evenNumbers = FilterArray(_numbers, _evenPredicate);

        }
    }
}
