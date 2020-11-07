using System;
using System.Diagnostics;
using System.Linq;
using NUnit.Framework;

namespace CH21Tests
{
    [TestFixture]
    public class CH21_03Tests
    {
        private static readonly int SearchValue;
        private static readonly int[] SortedValues;

        private static readonly int[] Values;
        private const int Max = 10_000_000;

        private Stopwatch _stopWatch;

        private static int[] GetRandomArray()
        {
            var random = new Random();
            return Enumerable.Range(1, Max)
                .Select(x => random.Next(1, Max))
                .ToArray();
        }

        static CH21_03Tests()
        {
            Values = GetRandomArray();
            SearchValue = Values[new Random().Next(0, Max - 1)];
            SortedValues = new int[Values.Length];
            Array.Copy(Values, SortedValues, Values.Length);
            Array.Sort(SortedValues);
        }

        [SetUp]
        public void Init()
        {
            _stopWatch = new Stopwatch();
            _stopWatch.Start();
        }

        [TearDown]
        public void Cleanup()
        {
            _stopWatch.Stop();
            Console.WriteLine(_stopWatch.ElapsedMilliseconds);
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

//        [Test]
//        public void LinearSearchTest()
//        {
//            int[] array = {1, 3, 5, 9, 11};
//            Assert.IsTrue(LinearSearch(array, 1) == 0);
//            Assert.IsTrue(LinearSearch(array, 5) == 2);
//            Assert.IsTrue(LinearSearch(array, 6) == -1);
//        }

        [Test]
        public void LinearSearchValuesTest()
        {
            var index = LinearSearch(Values, SearchValue);
            Assert.IsTrue(index > -1);
        }

        [Test]
        public void BinarySearchTest()
        {
            var index = Array.BinarySearch(SortedValues, SearchValue);
            Assert.IsTrue(index > -1);
        }
    }
}
