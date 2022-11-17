using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ShopDB.Services
{
    public class PersonService : IPersonService
    {
        private readonly ShopDBContext _context;

        public PersonService(ShopDBContext context)
        {
            this._context = context;
        }

        public Person AddPerson(int id, string name, string surname)
        {
            if (name == string.Empty || surname == string.Empty)
                throw new ArgumentNullException($"Provide {nameof(name)} and {nameof(surname)} please!");

            var person = _context.People.Add(new Person
            {
                Id = id,
                Name = name,
                Surname = surname
            });
            _context.SaveChanges();

            return person;
        }

        public List<Person> GetSortedPeople()
        {
            var people = from person in _context.People
                         orderby person.Name descending
                         select person;

            return people.ToList();
        }

        public async Task<List<Person>> GetSortedPeopleAsync()
        {
            var people = from person in _context.People
                         orderby person.Name descending
                         select person;

            return await people.ToListAsync();
        }

        public IEnumerable<Person> GetPeopleOlderThanDate(DateTime date)
        {
            return _context.People
                                    .Where(p => p.BirthDate.Year > date.Year)
                                    .ToList();
        }

        public async Task<IEnumerable<Person>> GetPeopleOlderThanDateAsync(object state)
        {
            DateTime date = (DateTime)state;
            return await _context.People
                                    .Where(p => p.BirthDate.Year > date.Year)
                                    .ToListAsync();
        }

        public Person GetPerson(Func<Person, bool> predicate)
        {
            return _context.People.FirstOrDefault(predicate);
        }

        public async Task<Person> GetPersonAsync(Expression<Func<Person, bool>> expression)
        {
            return await _context.People.FirstOrDefaultAsync(expression);
        }
    }
}
