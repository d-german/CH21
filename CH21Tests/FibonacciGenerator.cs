using System.Collections.Generic;

namespace CH21Tests
{
    public class FibonacciGenerator
    {
        private IDictionary<ulong, ulong> _cache;

        private FibonacciGenerator()
        {
        }

        public static FibonacciGenerator BuildFibonacciGenerator(string dictType)
        {
            var generator = new FibonacciGenerator();

            if (dictType.Equals("SortedDictionary"))
                generator._cache = new SortedDictionary<ulong, ulong>();
            else
                generator._cache = new Dictionary<ulong, ulong>();

            return generator;
        }

        public ulong Fib(ulong n)
        {
            Display(n);
            
            if (n == 1 || (n == 2))
            {
                return 1;
            }

            return Fib(n - 1) + Fib(n - 2);
        }

        public ulong FibFromCache(ulong key)
        {
            if (!_cache.ContainsKey(key))
            {
                _cache[key] = _fibonacci(key);
            }

            return _cache[key];
        }

        private ulong _fibonacci(ulong n)
        {
            Display(n);

            if ((n == 1) || (n == 2))
            {
                return 1;
            }

            return FibFromCache(n - 1) + FibFromCache(n - 2);
        }
        
        public ulong FibonacciNumber(ulong n)
        {
            ulong a = 0;
            ulong b = 1;

            for (ulong i = 0; i < n; i++)
            {
                Display(a);
                var tmp = a;
                a = b;
                b += tmp;
            }

            return a;
        }
        
        private static void Display(ulong n)
        {
            //Console.WriteLine($"n:= {n}");
        }
    }
}