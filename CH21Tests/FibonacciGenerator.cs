using System.Collections.Generic;

namespace CH21Tests
{
    public class FibonacciGenerator
    {
        private IDictionary<int, int> _cache;

        private FibonacciGenerator()
        {
        }

        public List<int> Nums { get; private set; }

        public static FibonacciGenerator BuildFibonacciGenerator(int n, string dictType)
        {
            var generator = new FibonacciGenerator();

            if (dictType.Equals("SortedDictionary"))
                generator._cache = new SortedDictionary<int, int>();
            else
                generator._cache = new Dictionary<int, int>();

            generator.BuildFibNums(n);

            return generator;
        }


        public static int FibonacciNumber(int n)
        {
            var a = 0;
            var b = 1;

            for (var i = 0; i < n; i++)
            {
                var tmp = a;
                a = b;
                b += tmp;
            }

            return a;
        }

        private int FibValue(int key)
        {
            if (!_cache.ContainsKey(key))
            {
                _cache[key] = FibonacciNumber(key);
            }

            return _cache[key];
        }

        private void BuildFibNums(int n)
        {
            Nums = new List<int>();
            for (var i = 0; i < n; i++)
            {
                Nums.Add(FibValue(i));
            }
        }
    }
}