using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Report.API.Entities
{
    public class PhoneBookReport
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonRepresentation(BsonType.DateTime)]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string Status { get; set; }

    }
}
