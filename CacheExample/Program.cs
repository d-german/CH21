using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

public class Program
{
    private static readonly IDictionary<int, int> Cache = new Dictionary<int, int>();

    private static int ExpensiveCalculation(int value)
    {
        Thread.Sleep(2000);
        return value * 50;
    }

    private static int GetFromCache(int item)
    {
        // Instead of performing the ExpensiveCalculation each time, use Cache with item for the key
        // and the ExpensiveCalculation(item) for the value.
        return ExpensiveCalculation(item);
    }

    private static void Main(string[] args)
    {
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        Console.WriteLine("....");
        Console.WriteLine(GetFromCache(5));
        Console.WriteLine(GetFromCache(10));
        Console.WriteLine(GetFromCache(5));
        Console.WriteLine(GetFromCache(10));
        stopwatch.Stop();
        Console.WriteLine($"Total run time {stopwatch.ElapsedMilliseconds} ms.");
    }
}
