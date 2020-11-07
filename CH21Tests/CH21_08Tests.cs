using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace CH21Tests
{
    public class CH21_08Tests
    {
        private delegate bool NumberPredicate(int number);

        private readonly NumberPredicate _evenPredicate = EvenPredicate2;

        private static bool EvenPredicate2(int number)
        {
            return number % 2 == 0;
        }

        private readonly NumberPredicate _evenPredicate2 = delegate(int number) { return number % 2 == 0; };
        private readonly NumberPredicate _evenPredicate3 = (int number) => { return number % 2 == 0; };
        private readonly NumberPredicate _evenPredicate4 = number => number % 2 == 0;
        private readonly NumberPredicate _evenPredicate5 = n => n % 2 == 0;

        private readonly int[] _numbers = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};

        private static IEnumerable<int> FilterArray(IEnumerable<int> array, NumberPredicate predicate)
        {
            var result = new List<int>();
            foreach (var num in array)
                if (predicate(num))
                    result.Add(num);

            return result;
        }

        private static IEnumerable<int> FilterArrayFunc(IEnumerable<int> array, Func<int, bool> predicate)
        {
            var result = new List<int>();
            foreach (var num in array)
                if (predicate(num))
                    result.Add(num);

            return result;
        }

        [Test]
        public void EvenNumberTest()
        {
            var evenNumbers = FilterArray(_numbers, _evenPredicate);
            CollectionAssert.AreEqual(new[] {2, 4, 6, 8, 10}, evenNumbers);
        }

        [Test]
        public void OddNumberTest()
        {
            var oddNumbers = FilterArrayFunc(_numbers, n => n % 2 == 1);
            CollectionAssert.AreEqual(new[] {1, 3, 5, 7, 9}, oddNumbers);
        }

        [Test]
        public void NumbersOver5Test()
        {
            var oddNumbers = FilterArrayFunc(_numbers, n => n > 5);
            CollectionAssert.AreEqual(new[] {6, 7, 8, 9, 10}, oddNumbers);
        }
    }
}
