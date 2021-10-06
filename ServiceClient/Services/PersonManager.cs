using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using ServiceClient.Validators;

namespace ServiceClient.Services
{
    public class PersonManager : IPersonManager
    {
        private readonly IPersonRepository _repository;
        private readonly IPersonAddValidator _addValidator;

        public PersonManager(IPersonRepository repository, 
            IPersonAddValidator addValidator)
        {
            _repository = repository;
            _addValidator = addValidator;
        }

        public IQueryable<Person> Load()
        {
            return _repository.Load();
        }

        public void Add(Person person)
        {
            _addValidator.ValidateAndThrow(person);

            try
            {
                _repository.Insert(person);
            }
            catch (DataStoreException e)
            {
                throw new PersonProcessException("Error adding person to datastore", e);
            }
        }
    }
}
