using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace digikey.Models
{
    public class Products
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string ProductName { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }
    }
}
