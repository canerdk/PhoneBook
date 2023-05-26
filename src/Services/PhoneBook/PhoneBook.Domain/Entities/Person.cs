using PhoneBook.Domain.Common;

namespace PhoneBook.Domain.Entities
{
    public class Person : EntityBase
    {
        public Person()
        {
            PersonContacts = new HashSet<PersonContact>();
        }

        public string FirsName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public virtual ICollection<PersonContact> PersonContacts { get; set; }
    }
}
