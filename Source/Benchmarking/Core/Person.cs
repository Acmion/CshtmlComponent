using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Benchmarking.Core
{
    public class Person
    {
        public static List<Person> AvailablePersons { get; } = GenerateRandomPersons(100);

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public Person(string firstName, string lastName, string phoneNumber) 
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
        }

        private static List<Person> GenerateRandomPersons(int n) 
        {
            var random = new Random(0);
            var persons = new List<Person>(n);

            for (var i = 0; i < n; i++) 
            {
                persons.Add(new Person(random.Next().ToString(), random.Next().ToString(), random.Next().ToString()));
            }

            return persons;
        }
    }
}
