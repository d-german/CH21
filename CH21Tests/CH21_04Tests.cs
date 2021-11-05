using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace CH21Tests
{
    [TestFixture]
    public class CH21_04Tests
    {
        [Test]
        public void TestAddUpdateDictTest()
        {
            var dictionary = new Dictionary<string, int>();

            dictionary.Add("One", 1);
            dictionary["Two"] = 2; // adds to dictionary because "two" not already present
            dictionary["Two"] = 22; // updates dictionary because "two" is now present
            dictionary["Three"] = 3;

            Assert.AreEqual(22, dictionary["Two"]);
            Assert.IsTrue(dictionary.ContainsKey("One")); // true (fast operation)
            Assert.IsTrue(dictionary.ContainsValue(3)); // true (slow operation)
        }

        [Test]
        public void TestEnumerateDictTest()
        {
            var dictionary = new Dictionary<string, int>
            {
                { "One", 1 },
                { "Two", 2 },
                //{"Two", 22 },
                { "Three", 3 }
            };

            dictionary["Two"] = 22; // updates dictionary because "two" is now present

            var buf = new StringBuilder();
            foreach (var kv in dictionary)
            {
                buf.Append($"{kv.Key}; {kv.Value} ");
            }

            Assert.AreEqual("One; 1 Two; 22 Three; 3 ", buf.ToString());

            buf.Clear();
            foreach (var str in dictionary.Keys)
            {
                buf.Append(str);
            }

            Assert.AreEqual("OneTwoThree", buf.ToString());

            buf.Clear();
            foreach (var value in dictionary.Values)
            {
                buf.Append(value);
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
                .Display(i => i ?? "-")
                .Where(n => !string.IsNullOrEmpty(n))
                .OrderBy(n => n)
                .Display();

            var item = hash.Retrieve("B_Two");

            item.DisplayItem();
        }
    }
}
