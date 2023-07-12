using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SCurveProject.Entities
{
    public class Notification
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = null!;

        [BsonRepresentation(BsonType.ObjectId)]
        public string UserId { get; set; } = null!;

        [BsonRepresentation(BsonType.ObjectId)]
        public string TaskId { get; set; } = null!;

        public string Message { get; set; } = null!;

        public DateTime CreatedAt { get; set; }
    }
}