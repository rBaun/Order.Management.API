using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using OrderManagement.Domain.Enums;

namespace OrderManagement.Domain.Models
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ProductId { get; set; }

        [BsonElement("title")] public string Title { get; set; }
        [BsonElement("price")] public double Price { get; set; }
        [BsonElement("description")] public string Description { get; set; }
        [BsonElement("category")] public string Category { get; set; }
        [BsonElement("image")] public string Image { get; set; }
        [BsonElement("id")] public int Id { get; set; }


        // TODO: Not yet implemented with playground data...
        // Add them later on in the project

        //public string Brand { get; set; }
        [BsonElement("stock")] public int Stock { get; set; }
        //public string ImageUrl { get; set; }
        [BsonElement("isNew")] public bool IsNew { get; set; }
        //public DateTime CreatedOn { get; set; }
        //public DateTime RestockedOn { get; set; }
        [BsonElement("productStatus")] public ProductStatus ProductStatus { get; set; }
    }
}
