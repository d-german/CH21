using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Numerics;

namespace ch21_tests
{
    public enum Type
    {
        Sorted,
        Hash,
        ConcurrentHash
    }

    public class FibonacciGenerator
    {
        private IDictionary<int, BigInteger> _cache;

        private FibonacciGenerator()
        {
        }

        public static FibonacciGenerator BuildGenerator(Type dictType)
        {
            var generator = new FibonacciGenerator();

            switch (dictType)
            {
                case Type.Sorted:
                    generator._cache = new SortedDictionary<int, BigInteger>();
                    break;
                case Type.Hash:
                    generator._cache = new Dictionary<int, BigInteger>();
                    break;
                case Type.ConcurrentHash:
                    generator._cache = new ConcurrentDictionary<int, BigInteger>();
                    break;
            }

            return generator;
        }

        public static int Fib(int n)
        {
            if (n == 1 || n == 2)
            {
                return 1;
            }

            return Fib(n - 1) + Fib(n - 2);
        }

        public BigInteger FibFromCache(int key)
        {
            if (!_cache.ContainsKey(key))
            {
                _cache[key] = Fibonacci(key);
            }

            return _cache[key];
        }

        private BigInteger Fibonacci(int n)
        {
            Display(n);
            if (n == 1 || n == 2)
            {
                return 1;
            }

            return FibFromCache(n - 1) + FibFromCache(n - 2);
        }

        public static BigInteger FibonacciNumber(int n)
        {
            BigInteger a = 0;
            BigInteger b = 1;

            for (var i = 1; i <= n; i++)
            {
                Display(i);
                var tmp = a;
                a = b;
                b += tmp;
            }

            return a;
        }

        private static void Display(int n)
        {
            Console.WriteLine($"n:= {n}");
        }
    }
}