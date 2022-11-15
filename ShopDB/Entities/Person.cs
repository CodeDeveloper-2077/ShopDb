using System;

namespace ShopDB
{
    public class Person : IComparable<Person>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public DateTime BirthDate { get; set; }

        public int CompareTo(Person other)
        {
            if (this.BirthDate > other.BirthDate)
                return 1;
            else if (this.BirthDate < other.BirthDate)
                return -1;

            else
                return 0;
        }
    }
}