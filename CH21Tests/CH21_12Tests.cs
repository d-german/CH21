using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CH21Tests
{
    [TestClass]
    public class CH21_12Tests
    {
        private static readonly int[] _values;
        private const int Max = 10000000;
        private static int[] GetRandomArray()
        {
            var random = new Random();
            return Enumerable.Range(1, Max)
                .Select(x => random.Next(1, Max))
                .ToArray();
        }

       static CH21_12Tests()
       {
           _values = GetRandomArray();
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
    }
}
