using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SCurveProject.Entities
{
    public class Project
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = null!;

        public string ProjectName { get; set; } = null!;

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Description { get; set; } = null!;
    }
}