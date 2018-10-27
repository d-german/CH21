using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CH21Tests
{
    [TestClass]
    public class CH21_11TestsInClass
    {
        private readonly List<Person> _persons = new List<Person>
        {
            new Person {Name = "Tom", Age = 10},
            new Person {Name = "Dick", Age = 5},
            new Person {Name = "Harry", Age = 5},
            new Person {Name = "Mary", Age = 5},
            new Person {Name = "Jay", Age = 20},
            new Person {Name = "George", Age = 20}
        };

        private readonly List<int> _values = new List<int> {3, 10, 6, 1, 4, 8, 2, 5, 9, 7};


        [TestMethod]
        public void TestMethod1()
        {
            var sum = _values.Aggregate(0, (x, y) => x + y);
            Assert.AreEqual(55, sum);
        }
    }
}