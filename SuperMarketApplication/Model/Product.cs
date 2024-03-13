using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SuperMarketApplication.Model
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public ObjectId Id { get; set; }
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public int Price { get; set; }
        public int PriceTotal { get; set;}
        public int Quantity { get; set; }

    }
}
