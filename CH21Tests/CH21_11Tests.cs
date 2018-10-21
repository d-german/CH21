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
            new Person {Name = "Tom", Age = 10},
            new Person {Name = "Dick", Age = 5},
            new Person {Name = "Harry", Age = 5},
            new Person {Name = "Mary", Age = 5},
            new Person {Name = "Jay", Age = 20}
        };

        private readonly List<int> _values = new List<int> {3, 10, 6, 1, 4, 8, 2, 5, 9, 7};


        [TestMethod]
        public void AggregateSumValues()
        {
            var sum = _values.Aggregate(0, (x, y) => x + y);
            Assert.AreEqual(55, sum);
        }

        [TestMethod]
        public void AggregateSumPersonsAges()
        {
            var sum = _persons.Aggregate(0, (x, p) => x + p.Age);
            Assert.AreEqual(45, sum);
        }

        [TestMethod]
        public void AggregateSumValuesPerson()
        {
            var person = _values.Aggregate(new Person {Age = 0, Name = "Bob"}, (p, n) =>
            {
                p.Age += n;
                return p;
            });
            Assert.AreEqual(55, person.Age);
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
                .OrderByDescending(value => value); // sort the values

            CollectionAssert.AreEqual(new[] {90, 70, 50, 30, 10}, query.ToArray());
        }

        [TestMethod]
        public void MapValuesOrderToPersons()
        {
            var query = _values
                .Where(n => n > 6)
                .OrderBy(value => value)
                .Select(n => new Person {Age = n * 2, Name = $"person #{n}"}).ToArray();

            Assert.AreEqual(
                "[ Name:=person #7, Age=14 ], [ Name:=person #8, Age=16 ], [ Name:=person #9, Age=18 ], [ Name:=person #10, Age=20 ],",
                query.Display());
        }

        [TestMethod]
        public void TakeZipToPersons()
        {
            var query = _values
                .OrderBy(value => value)
                .Take(5)
                .Zip(_persons, (v, p) =>
                {
                    p.Age = v;
                    return p;
                });

            Assert.AreEqual(
                "[ Name:=Tom, Age=1 ], [ Name:=Dick, Age=2 ], [ Name:=Harry, Age=3 ], [ Name:=Mary, Age=4 ], [ Name:=Jay, Age=5 ],",
                query.Display());
        }

        [TestMethod]
        public void DeferredExecution()
        {
            var numbers = new List<int> {1};

            var query = numbers.Select(n => n * 10); // Build query

            numbers.Add(2); // Sneak in an extra element

            Assert.AreEqual("10 20", query.Display());
        }

        [TestMethod]
        public void CapturedVariables()
        {
            Assert.AreEqual("20 40", CapturedEnumerable<int>().Display());
        }

        internal static IEnumerable<T> CapturedEnumerable<T>()
        {
            int[] numbers = {1, 2};

            var factor = 10;

            var query = numbers.Select(n => n * factor);

            factor = 20;

            return (IEnumerable<T>) query;
        }
    }


    internal class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return $"[ Name:={Name}, Age={Age} ],";
        }
    }

    // declares an extension method 
    internal static class Extensions
    {
        // extension method that displays all elements separated by spaces
        public static string Display<T>(this IEnumerable<T> data)
        {
            return string.Join(" ", data);
        }
    }
}