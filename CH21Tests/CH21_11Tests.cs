using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CH21Tests
{
    [TestClass]
    public class CH21_11Tests
    {
        private readonly List<Person> _persons = new List<Person>
        {
            new Person {Name = "Tom"},
            new Person {Name = "Dick"},
            new Person {Name = "Harry"},
            new Person {Name = "Mary"},
            new Person {Name = "Jay"}
        };

        private readonly List<int> _values = new List<int> {3, 10, 6, 1, 4, 8, 2, 5, 9, 7};


        [TestMethod]
        public void AggregateSumValues()
        {
            var sum = _values.Aggregate(0, (x, y) => x + y);
            Assert.AreEqual(55, sum);
        }

        [TestMethod]
        public void AggregateProductValues()
        {
            var product = _values.Aggregate(1, (x, y) => x * y);
            Assert.AreEqual(3628800, product);
        }

        [TestMethod]
        public void FilterAndOrderEvenValues()
        {
            var evenValueQuery = _values
                .Where(value => value % 2 == 0) // find even integers
                .OrderBy(value => value);

            CollectionAssert.AreEqual(new[] {2, 4, 6, 8, 10}, evenValueQuery.ToArray());
        }

        [TestMethod]
        public void OddValuesMulBy10AndOrder()
        {
            var query = _values
                .Where(value => value % 2 != 0) // find odd integers
                .Select(value => value * 10) // multiply each by 10
                .OrderBy(value => value); // sort the values

            CollectionAssert.AreEqual(new[] {10, 30, 50, 70, 90}, query.ToArray());
        }

        [TestMethod]
        public void MapValuesOrderToPersons()
        {
            var query = _values
                .Where(n => n > 6)
                .OrderBy(value => value)
                .Select(n => new Person {Age = n * 2, Name = $"person #{n}"}); // sort the values

            CollectionAssert.AreEqual(new[]
            {
                new Person {Age = 14, Name = "person #7"},
                new Person {Age = 16, Name = "person #8"},
                new Person {Age = 18, Name = "person #9"},
                new Person {Age = 20, Name = "person #10"}
            }, query.ToArray());
        }
    }

    internal class Person : IComparer<Person>
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int Compare(Person x, Person y)
        {
            return x.Name.CompareTo(y.Name);
        }
    }
}