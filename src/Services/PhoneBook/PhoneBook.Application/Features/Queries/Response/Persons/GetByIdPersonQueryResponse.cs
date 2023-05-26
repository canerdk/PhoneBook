using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Application.Features.Queries.Response.Persons
{
    public class GetByIdPersonQueryResponse
    {
        public Guid Id { get; set; }
        public string FirsName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
    }
}
