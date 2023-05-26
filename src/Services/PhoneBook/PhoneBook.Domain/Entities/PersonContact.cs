using PhoneBook.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Domain.Entities
{
    public class PersonContact : EntityBase
    {
        public ContactType Type { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public Guid PersonId { get; set; }
        public virtual Person Person { get; set; }
    }

    

}
