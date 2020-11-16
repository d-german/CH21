using System;
using System.Diagnostics;
using System.Linq;
using NUnit.Framework;
using static CH21Tests.Extensions;

namespace CH21Tests
{
    [TestFixture]
    public class EagerLazyTests
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
        public void GetInts()
        {
            var ints = Extensions.GetInts();

            foreach (var value in ints)
            {
                Console.WriteLine($"---{value}---");
            }
        }

        [Test]
        public void EagerExecution()
        {
            var results = GetRangeEager(0, 500).FilterEager(i => i < 25).Take(4);
            Assert.AreEqual("0 1 2 3", results.Display());
        }

        [Test]
        public void LazyExecution()
        {
            var results = GetRangeLazy(0, 500).FilterLazy(i => i < 25).Take(4);
            Assert.AreEqual("0 1 2 3", results.Display());
        }
    }
}
