using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShopDB.Services
{
    public interface IPersonService
    {
        Person AddPerson(int id, string name, string surname);
        Person GetPerson(Func<Person, bool> predicate);
        Task<Person> GetPersonAsync(Expression<Func<Person, bool>> expression);
        List<Person> GetSortedPeople();
        Task<List<Person>> GetSortedPeopleAsync();
        IEnumerable<Person> GetPeopleOlderThanDate(DateTime date);
        Task<IEnumerable<Person>> GetPeopleOlderThanDateAsync(object state);
    }
}
