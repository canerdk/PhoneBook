using MongoDB.Driver;
using Report.API.Entities;

namespace Report.API.DataAccess
{
    public class ReportContext : IReportContext
    {
        public ReportContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));
            PhoneBookReports = database.GetCollection<PhoneBookReport>("PhoneBookReports");
            ReportDetails = database.GetCollection<ReportDetail>("ReportDetails");
        }

        public IMongoCollection<PhoneBookReport> PhoneBookReports { get; }

        public IMongoCollection<ReportDetail> ReportDetails { get; }
    }
}
