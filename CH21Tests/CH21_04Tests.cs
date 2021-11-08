using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using static CH21Tests.MediaTypeToFileName;

// ReSharper disable UseObjectOrCollectionInitializer

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
            foreach (var (key, value) in dictionary) // tuple deconstruction
            {
                buf.Append($"{key}; {value} ");
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

        // ************** Explain SSN example and LoadFactor ***********************
        [Test]
        public void HashToIndexTest()
        {
            var hashSet = new string[8];
            hashSet.Insert("A_One");
            hashSet.Insert("B_Two");
            hashSet.Insert("C_Three");
            hashSet.Insert("D_Four");
            hashSet.Insert("E_Five");
            hashSet.Insert("F_Six");
            hashSet.Insert("G_Seven");
            hashSet.Insert("H_Eight");
            hashSet.Insert("I_Nine");
            hashSet.Insert("J_Ten");
            hashSet.Insert("K_Eleven");

            _ = hashSet
                .Display(i => i ?? "-")
                .Where(n => !string.IsNullOrEmpty(n))
                .OrderBy(n => n)
                .Display();

            // var item = hashSet.Retrieve("B_Two");
            //
            // item.DisplayItem();
        }

        [Test]
        public void MediaTypeToFileImperative()
        {
            Assert.That(GetFileNameImperativeSwitchStatement(Word), Is.EqualTo(MsWordFileName));
        }

        [Test]
        public void MediaTypeToFileExpressive()
        {
            Assert.That(GetFileNameDeclarative(Word), Is.EqualTo(MsWordFileName));
        }

        [Test]
        public void MediaTypeToFileExpressiveNoDefault()
        {
            Assert.Throws<KeyNotFoundException>(() => { _ = GetFileNameDeclarativeNoDefault("bogus"); });
        }
    }
}
