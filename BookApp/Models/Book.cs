using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace BookApp.Models
{
    public class Book
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonRequired]
        [BsonElement("Name")]
        public string Name { get; set; } = null!;

        [BsonRequired]
        [BsonElement("Genre")]

        public string Genre { get; set; } = null!;

        [BsonRequired]
        [BsonElement("Author")]
        public string Author { get; set; } = null!;

        [BsonRequired]
        [BsonElement("Description")]
        public string Description { get; set; } = null!;

    }
}
