using System.Linq;

namespace ServiceClient.Services
{
    public interface IPersonManager
    {
        IQueryable<Person> Load();
        void Add(Person person);
    }
}