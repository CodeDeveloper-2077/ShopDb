using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ShopDB.Entities;

namespace ShopDB.Services
{
    public interface IPersonService
    {
        Person AddPerson(int id, string name, string surname);
        Person GetPerson(Expression<Func<Person, bool>> predicate);
        Task<Person> GetPersonAsync(Expression<Func<Person, bool>> expression);
        IEnumerable<Person> GetPeople(Expression<Func<Person, bool>> predicate);
        Task<IEnumerable<Person>> GetPeopleAsync(Expression<Func<Person, bool>> expression);
        List<Person> GetSortedPeople<TKey>(Expression<Func<Person, TKey>> expression, SortMode sortMode);
        Task<List<Person>> GetSortedPeopleAsync<TKey>(Expression<Func<Person, TKey>> expression, SortMode sortMode);
    }
}
