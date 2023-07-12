using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SCurveProject.Entities
{
    public class MicroTask
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = null!;

        [BsonRepresentation(BsonType.ObjectId)]
        public string TaskId { get; set; } = null!;

        public string MicroTaskName { get; set; } = null!;

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string AssignedTo { get; set; } = null!;

        public int Progress { get; set; }
    }
}