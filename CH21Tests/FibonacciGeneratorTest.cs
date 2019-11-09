using System;
using System.Diagnostics;
using NUnit.Framework;

namespace CH21Tests
{
    public class FibonacciGeneratorTest
    {
        private Stopwatch _stopWatch;

        // small
        private const int N = 6;
        private const ulong Result = 8;

//        private const int N = 20;
//        private const ulong Result = 6765;

        // medium
//        private const int N = 40;
//        private const ulong Result = 102334155;

        // large
//        private const int N = 45;
//        private const ulong Result = 1134903170;

//        private const int N = 4000;
//        private const ulong Result = 483944808890094715;

        // large causes stack overflow
//        private const int N = 4156;
//        private const ulong Result = 16574604806748148403;

//        private const int N = 99999;
//        private const ulong Result = 535601498209671957;

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

        //[Test]
        public void Recursive()
        {
            var gen = FibonacciGenerator.BuildFibonacciGenerator("");
            var result = gen.Fib(N);
            Assert.AreEqual(Result, result);
        }

        [Test]
        public void NonRecursive()
        {
            var gen = FibonacciGenerator.BuildFibonacciGenerator("");
            var result = gen.FibonacciNumber(N);
            Assert.AreEqual(Result, result);
        }

        [Test]
        public void SortedCached()
        {
            var gen = FibonacciGenerator.BuildFibonacciGenerator("SortedDictionary");
            var result = gen.FibFromCache(N);
            Assert.AreEqual(Result, result);
        }

        [Test]
        public void HashCached()
        {
            var gen = FibonacciGenerator.BuildFibonacciGenerator("");
            var result = gen.FibFromCache(N);

            Assert.AreEqual(Result, result);
        }
    }
}