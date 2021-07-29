using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using OrderManagement.Domain.Enums;

namespace OrderManagement.Domain.Models
{
    public class Customer
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string CustomerId { get; set; }

        [BsonElement("firstName")] public string FirstName { get; set; }
        [BsonElement("lastName")] public string LastName { get; set; }
        [BsonElement("address")] public string Address { get; set; }
        [BsonElement("mail")] public string Mail { get; set; }
        [BsonElement("phone")] public string Phone { get; set; }
        [BsonElement("customerStatus")] public CustomerStatus CustomerStatus { get; set; }
    }
}