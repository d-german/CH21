using System;
using System.Collections.Generic;

namespace CH21Tests
{
    public class FibonacciGenerator
    {
        private IDictionary<int, int> _cache;

        private FibonacciGenerator()
        {
        }

        public static FibonacciGenerator BuildFibonacciGenerator(string dictType)
        {
            var generator = new FibonacciGenerator();

            if (dictType.Equals("SortedDictionary"))
                generator._cache = new SortedDictionary<int, int>();
            else
                generator._cache = new Dictionary<int, int>();

            return generator;
        }

        public int Fib(int n)
        {
            Console.WriteLine($"n:= {n}");

            if (n == 1 || (n == 2))
            {
                return 1;
            }

            return Fib(n - 1) + Fib(n - 2);
        }

        public int FibFromCache(int key)
        {
            if (!_cache.ContainsKey(key))
            {
                _cache[key] = _fibonacci(key);
            }

            return _cache[key];
        }

        private int _fibonacci(int n)
        {
            Console.WriteLine($"n:= {n}");

            if ((n == 1) || (n == 2))
            {
                return 1;
            }

            return FibFromCache(n - 1) + FibFromCache(n - 2);
        }
    }
}