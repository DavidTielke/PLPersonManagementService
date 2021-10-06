using System;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceClient.Services
{
    public class PersonManager : IPersonManager
    {
        private readonly IPersonRepository _repository;

        public PersonManager(IPersonRepository repository)
        {
            _repository = repository;
        }

        public IQueryable<Person> Load()
        {
            return _repository.Load();
        }
    }
}
