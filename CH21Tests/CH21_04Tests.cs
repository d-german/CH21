using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace CH21Tests
{
    public static class Helpers
    {
        private static int HashToIndex<T>(T val, int arraySize)
        {
            var index = Math.Abs(val.GetHashCode()) % arraySize;
            Console.WriteLine($"Inserting {val} at position {index}");
            return index;
        }

        public static void Insert<T>(this IList<T> items, T item)
        {
            items[HashToIndex(item, items.Count)] = item;
        }
    }

    [TestFixture]
    public class CH21_04Tests
    {
        private Stopwatch _stopWatch;

        [SetUp]
        public void Init()
        {
            _stopWatch = new Stopwatch();
            _stopWatch.Start();
        }

        [TearDown]
        public void Cleanup()
        {
            _stopWatch.Stop();
            Console.WriteLine(_stopWatch.ElapsedMilliseconds);
        }

        [Test]
        public void TestAddUpdateDictTest()
        {
            var d = new Dictionary<string, int>();

            d.Add("One", 1);
            d["Two"] = 2; // adds to dictionary because "two" not already present
            d["Two"] = 22; // updates dictionary because "two" is now present
            d["Three"] = 3;

            Assert.AreEqual(22, d["Two"]);
            Assert.IsTrue(d.ContainsKey("One")); // true (fast operation)
            Assert.IsTrue(d.ContainsValue(3)); // true (slow operation)
        }

        [Test]
        public void TestEnumerateDictTest()
        {
            var d = new Dictionary<string, int>
            {
                {"One", 1},
                {"Two", 2},
                //{"Two", 22 },
                {"Three", 3}
            };

            d["Two"] = 22; // updates dictionary because "two" is now present

            var buf = new StringBuilder();
            foreach (var kv in d)
            {
                buf.Append($"{kv.Key}; {kv.Value} ");
            }

            Assert.AreEqual("One; 1 Two; 22 Three; 3 ", buf.ToString());

            buf.Clear();
            foreach (var s in d.Keys)
            {
                buf.Append(s);
            }

            Assert.AreEqual("OneTwoThree", buf.ToString());

            buf.Clear();
            foreach (var v in d.Values)
            {
                buf.Append(v);
            }

            Assert.AreEqual("1223", buf.ToString());
        }

        [Test]
        public void HashToIndexTest()
        {
            var hash = new string[8];
            hash.Insert("A_One");
            hash.Insert("B_Two");
            hash.Insert("C_Three");
            hash.Insert("D_Four");
            hash.Insert("E_Five");
            hash.Insert("F_Six");
            hash.Insert("G_Seven");
            hash.Insert("H_Eight");
            hash.Insert("I_Nine");
            hash.Insert("J_Ten");
            hash.Insert("K_Eleven");

            _ = hash
                .Select(value =>
                {
                    Console.WriteLine(value ?? "-");
                    return value;
                })
                .Where(n => !string.IsNullOrEmpty(n))
                .Select(n => n)
                .OrderBy(n => n)
                .ToList();
        }
    }
}
