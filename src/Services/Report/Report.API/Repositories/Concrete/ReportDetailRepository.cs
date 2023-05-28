using Report.API.Entities;
using Report.API.Repositories.Abstract;

namespace Report.API.Repositories.Concrete
{
    public class ReportDetailRepository : MongoGenericRepository<ReportDetail>, IReportDetailRepository
    {
        public ReportDetailRepository(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
