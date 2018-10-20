using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CH21Tests
{
    [TestClass]
    public class CH21_03Tests
    {
        private static readonly int _searchValue;
        private static readonly int[] _sortedValues;

        private static readonly int[] _values;
        private const int Max = 10000000;

        static CH21_03Tests()
        {
            _values = GetRandomArray();
            _searchValue = _values[new Random().Next(0, Max -1)];
            _sortedValues = new int[_values.Length];
            Array.Copy(_values, _sortedValues, _values.Length);
            Array.Sort(_sortedValues);
        }

        private static int[] GetRandomArray()
        {
            var random = new Random();
            return Enumerable.Range(1, Max)
                .Select(x => random.Next(1, Max))
                .ToArray();
        }

        private static int LinearSearch(int[] array, int value)
        {
            var enumerator = array.GetEnumerator();
            var position = -1;
            var isFound = false;
            while (!isFound && enumerator.MoveNext())
            {
                position++;
                if (enumerator.Current != null && (int) enumerator.Current == value)
                {
                    isFound = true;
                }
            }

            return isFound ? position : -1;
        }


//        [TestMethod]
//        public void LinearSearchTest()
//        {
//            int[] array = {1, 3, 5, 9, 11};
//            Assert.IsTrue(LinearSearch(array, 1) == 0);
//            Assert.IsTrue(LinearSearch(array, 5) == 2);
//            Assert.IsTrue(LinearSearch(array, 6) == -1);
//        }

        [TestMethod]
        public void LinearSearchValuesTest()
        {
            int index = LinearSearch(_values, _searchValue);
            Assert.IsTrue(index > -1);
        }

        [TestMethod]
        public void BinarySearchTest()
        {
            var index = Array.BinarySearch(_sortedValues, _searchValue);
            Assert.IsTrue(index > -1);
        }
    }
}