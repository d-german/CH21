﻿using System.Collections.Generic;
using NUnit.Framework;

namespace CH21Tests
{
    public class FibonacciGeneratorTest
    {
        private readonly List<int> First21Fibs = new List<int>
        {
            0,
            1,
            1,
            2,
            3,
            5,
            8,
            13,
            21,
            34,
            55,
            89,
            144,
            233,
            377,
            610,
            987,
            1597,
            2584,
            4181,
            6765
        };

        private static List<int> GetFibNums(int n)
        {
            var nums = new List<int>();
            for (var i = 0; i < n; i++) nums.Add(FibonacciGenerator.FibonacciNumber(i));
            return nums;
        }

        [Test]
        public void GetFibNumsTest()
        {
            var fibs = GetFibNums(21);
            CollectionAssert.AreEqual(First21Fibs, fibs);
        }

        [Test]
        public void FibonacciSortedDictGeneratorTest()
        {
            var gen = FibonacciGenerator.BuildFibonacciGenerator(21, "SortedDictionary");
            CollectionAssert.AreEqual(First21Fibs, gen.Nums);
        }

        [Test]
        public void FibonacciDictGeneratorTest()
        {
            var gen = FibonacciGenerator.BuildFibonacciGenerator(21, "Dictionary");
            CollectionAssert.AreEqual(First21Fibs, gen.Nums);
        }
    }
}