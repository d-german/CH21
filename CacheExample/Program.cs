using System;
using System.Collections.Generic;
using System.Threading;

public class Program
{
    private static readonly IDictionary<int, int> Cache = new Dictionary<int, int>();

    private static int ExpensiveCalculation(int value)
    {
        Thread.Sleep(2000);
        return value * 50;
    }

    private static int GetValue(int key)
    {
        if(Cache.ContainsKey(key))
        {
            ++Cache[key];
        }
        else
        {
            Cache.Add(key, 1);
        }

        return key;
    }

    private static void Main(string[] args)
    {
        Console.WriteLine("....");
        Console.WriteLine(GetValue(5));
        Console.WriteLine(GetValue(10));
        Console.WriteLine(GetValue(5));
        Console.WriteLine(GetValue(10));
    }
}
