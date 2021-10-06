using System.Linq;

namespace ServiceClient.Services
{
    public interface IPersonManager
    {
        IQueryable<Person> Load();
    }
}