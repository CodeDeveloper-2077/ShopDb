using System.Collections.Generic;

namespace ShopDB
{
    public class PersonContact
    {
        public int Id { get; set; }

        public Person Person { get; set; }
        public int? PersonId { get; set; }

        public ICollection<ContactType> ContactTypes { get; set; }

        public string ContactValue { get; set; }

        public PersonContact()
        {
            ContactTypes = new HashSet<ContactType>();
        }
    }
}