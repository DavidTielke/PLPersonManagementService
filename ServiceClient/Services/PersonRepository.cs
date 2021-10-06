using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using FluentValidation;
using ServiceClient.Validators;

namespace ServiceClient.Services
{
    public class PersonRepository : IPersonRepository
    {
        private readonly List<Person> _persons;
        private readonly IPersonInsertValidator _insertValidator;

        public PersonRepository(IPersonInsertValidator insertValidator)
        {
            _insertValidator = insertValidator;
        }

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
            _insertValidator.ValidateAndThrow(person);

            person.Id = _persons.Max(p => p.Id) + 1;
            _persons.Add(person);
        }
    }
}