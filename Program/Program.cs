using System;
using System.Collections.Generic;
using System.Linq;

namespace Program
{
    internal class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return $"[ Name:={Name}, Age={Age} ],";
        }
    }

    static class Program
    {
        private static readonly List<Person> _persons = new List<Person>
        {
            new Person {Name = "Tom", Age = 10},
            new Person {Name = "Dick", Age = 5},
            new Person {Name = "Harry", Age = 5},
            new Person {Name = "Mary", Age = 5},
            new Person {Name = "Jay", Age = 20},
            new Person {Name = "George", Age = 20}
        };

        private static readonly List<int> _values = new List<int> {3, 10, 6, 1, 4, 8, 2, 5, 9, 7};

        private static void Main()
        {
            var query = _persons.Select(p => new {Foo = p.Name, Bar = p.Age});
            foreach (var item in query)
            {
                Console.WriteLine($"{item.Foo} {item.Bar}");
            }
        }
    }
}