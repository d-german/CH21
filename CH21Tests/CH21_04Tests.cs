using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace CH21Tests
{
    [TestFixture]
    public class CH21_04Tests
    {

        private static int HashToIndex<T>(T val, int arraySize)
        {
            return Math.Abs(val.GetHashCode()) % arraySize;
        }

        private static void Insert<T>(IList<T> items, T item)
        {
            var index = HashToIndex(item, items.Count);
            items[index] = item;
        }
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
            Insert(hash, "A_One");
            Insert(hash, "B_Two");
            Insert(hash, "C_Three");
            Insert(hash, "D_Four");
            Insert(hash, "E_Five");
            Insert(hash, "F_Six");
            Insert(hash, "G_Seven");
            Insert(hash, "H_Eight");
            Insert(hash, "I_Nine");
            Insert(hash, "J_Ten");
            Insert(hash, "K_Eleven");

            var items = hash
                .Select(a =>
                {
                    Console.WriteLine(a ?? "-");
                    return a;
                })
                .Where(n => !string.IsNullOrEmpty(n))
                .Select(n => n)
                .OrderBy(n => n)
                .ToList();
        }
    }
}