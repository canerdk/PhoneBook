using PhoneBook.Application.Contracts.Persistence;
using PhoneBook.Domain.Entities;
using PhoneBook.Infrastructure.Persistence;

namespace PhoneBook.Infrastructure.Repositories
{
    public class PersonContactRepository : RepositoryBase<PersonContact>, IPersonContactRepository
    {
        public PersonContactRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
