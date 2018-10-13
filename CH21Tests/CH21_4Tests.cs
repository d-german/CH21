using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CH21Tests
{
    [TestClass]
    public class CH21_4Tests
    {
        [TestMethod]
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

        [TestMethod]
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
            foreach (var kv in d) buf.Append($"{kv.Key}; {kv.Value} ");
            Assert.AreEqual("One; 1 Two; 22 Three; 3 ", buf.ToString());

            buf.Clear();
            foreach (var s in d.Keys) buf.Append(s);
            Assert.AreEqual("OneTwoThree", buf.ToString());

            buf.Clear();
            foreach (var v in d.Values) buf.Append(v);
            Assert.AreEqual("1223", buf.ToString());

        }
    }
}