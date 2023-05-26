using PhoneBook.Application.Contracts.Persistence;
using PhoneBook.Domain.Entities;
using PhoneBook.Infrastructure.Persistence;

namespace PhoneBook.Infrastructure.Repositories
{
    public class PersonRepository : RepositoryBase<Person>, IPersonRepository
    {
        public PersonRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
