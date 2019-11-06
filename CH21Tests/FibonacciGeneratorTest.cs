using System;
using System.Diagnostics;
using NUnit.Framework;

namespace CH21Tests
{
    public class FibonacciGeneratorTest
    {
        private Stopwatch _stopWatch;

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

        [Test]
        public void SmallSlow()
        {
            var gen = FibonacciGenerator.BuildFibonacciGenerator("");
            var result = gen.Fib(6);
            Assert.AreEqual(8, result);
        }

        [Test]
        public void SmallSorted()
        {
            var gen = FibonacciGenerator.BuildFibonacciGenerator("SortedDictionary");
            var result = gen.FibFromCache(6);
            Assert.AreEqual(8, result);
        }

        //[Test]
        public void LargeSlow()
        {
            var gen = FibonacciGenerator.BuildFibonacciGenerator("SortedDictionary");
            var result = gen.Fib(45);
            Assert.AreEqual(1134903170, result);
        }

        [Test]
        public void LargeHash()
        {
            var gen = FibonacciGenerator.BuildFibonacciGenerator("");
            var result = gen.FibFromCache(45);

            Assert.AreEqual(1134903170, result);
        }

        [Test]
        public void LargeSorted()
        {
            var gen = FibonacciGenerator.BuildFibonacciGenerator("SortedDictionary");
            var result = gen.FibFromCache(45);

            Assert.AreEqual(1134903170, result);
        }
    }
}