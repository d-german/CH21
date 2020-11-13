using System;
using System.Diagnostics;
using System.Linq;
using static LazyExample.Extensions;

namespace LazyExample
{
    internal class Program
    {
        private static void Main()
        {
            var sw = new Stopwatch();
            sw.Start();
            //var results = GetRangeEager(0, 1000).FilterEager(i => i < 50).Take(4);
            var results = GetRangeLazy(0, 1000).FilterLazy(i => i < 50).Take(4);

            foreach (var i in results)
            {
                Console.WriteLine($"*** Result {i} ***");
            }

            Console.WriteLine($"execution time {sw.ElapsedMilliseconds} ms");
        }
    }
}
