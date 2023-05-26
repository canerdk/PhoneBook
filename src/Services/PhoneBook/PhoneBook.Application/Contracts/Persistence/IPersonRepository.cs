using PhoneBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Application.Contracts.Persistence
{
    public interface IPersonRepository : IAsyncRepository<Person>
    {
    }
}
