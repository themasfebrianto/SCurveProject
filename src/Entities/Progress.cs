using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SCurveProject.Entities
{
    public class Progress
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = null!;

        [BsonRepresentation(BsonType.ObjectId)]
        public string TaskId { get; set; } = null!;

        public DateTime Date { get; set; }

        public int CompletedPercentage { get; set; }
    }
}