using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Report.API.Entities
{
    public class PhoneBookReport : MongoEntity
    {

        [BsonRepresentation(BsonType.DateTime)]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string Status { get; set; }

        public PhoneBookReport(string status)
        {
            Status = status;
        }

    }
}
