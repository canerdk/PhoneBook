using MongoDB.Driver;
using Report.API.Entities;

namespace Report.API.DataAccess
{
    public interface IReportContext
    {
        IMongoCollection<PhoneBookReport> PhoneBookReports { get; }
        IMongoCollection<ReportDetail> ReportDetails { get; }
    }
}
