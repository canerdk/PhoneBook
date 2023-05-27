using Report.API.Entities;
using Report.API.Repositories.Abstract;

namespace Report.API.Repositories.Concrete
{
    public class PhoneBookReportRepository : MongoGenericRepository<PhoneBookReport>, IPhoneBookReportRepository
    {
        public PhoneBookReportRepository(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
