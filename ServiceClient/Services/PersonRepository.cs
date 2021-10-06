using System.Collections.Generic;
using System.Linq;

namespace ServiceClient.Services
{
    public class PersonRepository : IPersonRepository
    {
        public IQueryable<Person> Load()
        {
            return new List<Person>
            {
                new Person(1, "David", 37),
                new Person(2, "Lena", 34),
                new Person(3, "Maximilian", 8),
            }.AsQueryable();
        }
    }
}