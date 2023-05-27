using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Report.API.Entities
{
    public class ReportDetail
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }        
        public string Location { get; set; }
        public int PersonCount { get; set; }
        public int PhoneNumberCount { get; set; }
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ReportId { get; set; }
    }
}
