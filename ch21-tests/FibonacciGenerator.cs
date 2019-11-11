using System.Collections.Generic;
using System.Numerics;

namespace ch21_tests
{
    public class FibonacciGenerator
    {
        private IDictionary<BigInteger, BigInteger> _cache;

        private FibonacciGenerator()
        {
        }

        public static FibonacciGenerator BuildFibonacciGenerator(string dictType)
        {
            var generator = new FibonacciGenerator();

            if (dictType.Equals("SortedDictionary"))
                generator._cache = new SortedDictionary<BigInteger, BigInteger>();
            else
                generator._cache = new Dictionary<BigInteger, BigInteger>();

            return generator;
        }

        public BigInteger Fib(BigInteger n)
        {
            Display(n);
            
            if (n == 1 || (n == 2))
            {
                return 1;
            }

            return Fib(n - 1) + Fib(n - 2);
        }

        public BigInteger FibFromCache(BigInteger key)
        {
            if (!_cache.ContainsKey(key))
            {
                _cache[key] = _fibonacci(key);
            }

            return _cache[key];
        }

        private BigInteger _fibonacci(BigInteger n)
        {
            Display(n);

            if ((n == 1) || (n == 2))
            {
                return 1;
            }

            return FibFromCache(n - 1) + FibFromCache(n - 2);
        }
        
        public BigInteger FibonacciNumber(BigInteger n)
        {
            BigInteger a = 0;
            BigInteger b = 1;

            for (BigInteger i = 0; i < n; i++)
            {
                Display(a);
                var tmp = a;
                a = b;
                b += tmp;
            }

            return a;
        }
        
        private static void Display(BigInteger n)
        {
            //Console.WriteLine($"n:= {n}");
        }
    }
}