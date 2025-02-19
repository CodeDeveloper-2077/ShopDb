﻿using ShopDB.Entities;
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

        public List<Person> GetSortedPeople<TKey>(Expression<Func<Person, TKey>> expression, SortMode mode)
        {
            var people = (mode == SortMode.Ascending) 
                                                        ? _context.People.OrderBy(expression) 
                                                        : _context.People.OrderByDescending(expression);

            return people.ToList();
        }

        public async Task<List<Person>> GetSortedPeopleAsync<TKey>(Expression<Func<Person, TKey>> expression, SortMode mode)
        {
            var people = (mode == SortMode.Ascending) 
                                                        ? _context.People.OrderBy(expression) 
                                                        : _context.People.OrderByDescending(expression);

            return await people.ToListAsync();
        }

        public IEnumerable<Person> GetPeople(Expression<Func<Person, bool>> predicate)
        {
            return _context.People
                                    .Where(predicate)
                                    .ToList();
        }

        public async Task<IEnumerable<Person>> GetPeopleAsync(Expression<Func<Person, bool>> expression)
        {
            return await _context.People
                                    .Where(expression)
                                    .ToListAsync();
        }

        public Person GetPerson(Expression<Func<Person, bool>> predicate)
        {
            return _context.People.FirstOrDefault(predicate);
        }

        public async Task<Person> GetPersonAsync(Expression<Func<Person, bool>> expression)
        {
            return await _context.People.FirstOrDefaultAsync(expression);
        }
    }
}
