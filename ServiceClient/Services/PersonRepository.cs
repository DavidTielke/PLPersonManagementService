using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ServiceClient.Services
{
    public class PersonRepository : IPersonRepository
    {
        private readonly List<Person> _persons;

        public PersonRepository()
        {
            _persons = new List<Person>
            {
                new Person(1, "David", 37),
                new Person(2, "Lena", 34),
                new Person(3, "Maximilian", 8),
            };
        }

        public IQueryable<Person> Load()
        {
            return _persons.AsQueryable();
        }

        public void Insert(Person person)
        {
            _persons.Add(person);
        }
    }
}