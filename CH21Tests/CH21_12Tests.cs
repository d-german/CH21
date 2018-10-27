using System;
using System.Configuration;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CH21Tests
{
    [TestClass]
    public class CH21_12Tests
    {
        private const int Max = 10000000;
        private static readonly int[] _values;

        static CH21_12Tests()
        {
            _values = GetRandomArray();
        }

        private static int[] GetRandomArray()
        {
            var random = new Random();
            return Enumerable.Range(1, Max)
                .Select(x => random.Next(1, Max))
                .ToArray();
        }

        [TestMethod]
        public void MaxTest()
        {
            var max = _values.Max();
        }

        [TestMethod]
        public void AvgTest()
        {
            var avg = _values.Average();
        }

        [TestMethod]
        public void MaxAsParallelTest()
        {
            var max = _values.AsParallel().Max();
        }

        [TestMethod]
        public void AvgAsParallelTest()
        {
            var avg = _values.AsParallel().Average();
        }

        [TestMethod]
        public void PrimeNumbersTest()
        {
            // Calculate prime numbers using a simple (unoptimized) algorithm.
            // This calculates prime numbers between 3 and a million, using all available cores:

            var numbers = Enumerable.Range(3, 1000000 - 3);

            var parallelQuery = numbers
                .AsParallel()
                .Where(n => Enumerable.Range(2, (int) Math.Sqrt(n)).All(i => n % i > 0))
                .OrderBy(p => p);

            var primes = parallelQuery.ToArray();
            var last = primes.Last();
            Assert.AreEqual(999983, last);
        }
    }
}