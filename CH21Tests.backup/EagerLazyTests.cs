using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using NUnit.Framework;
using static CH21Tests.Extensions;

namespace CH21Tests
{
    [TestFixture]
    public class EagerLazyTests
    {
        private static IEnumerable<string> UVtoIR()
        {
            yield return "violet";
            yield return "blue";
            yield return "cyan";
            yield return "green";
            yield return "yellow";
            yield return "orange";
            yield return "red";
        }

        private static IEnumerable<string> IRtoUV()
        {
            string[] colors = {"violet", "blue", "cyan", "green", "yellow", "orange", "red"};

            for (var i = colors.Length - 1; i >= 0; i--)
            {
                yield return colors[i];
            }
        }

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
            Console.WriteLine($"{_stopWatch.ElapsedMilliseconds} ms");
        }

        [Test]
        public void GetSpectrum()
        {
            foreach (var color in UVtoIR())
            {
                Console.WriteLine($"{color}");
            }

            Console.WriteLine("--------------");

            foreach (var color in IRtoUV())
            {
                Console.WriteLine($"{color}");
            }
        }

        [Test]
        public void EagerExecution()
        {
            var results = GetRangeEager(0, 500).FilterEager(i => i < 25).TakeEager(4);
            Assert.AreEqual("0 1 2 3", results.Display());
        }

        [Test]
        public void LazyExecution()
        {
            var results = GetRangeLazy(0, 500).FilterLazy(i => i < 25).TakeLazy(4);
            Assert.AreEqual("0 1 2 3", results.Display());
        }
    }
}
