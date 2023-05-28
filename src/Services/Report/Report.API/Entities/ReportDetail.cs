using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Report.API.Entities
{
    public class ReportDetail : MongoEntity
    {
        public string Location { get; set; }
        public int PersonCount { get; set; }
        public int PhoneNumberCount { get; set; }
        public string ReportId { get; set; }
    }
}
