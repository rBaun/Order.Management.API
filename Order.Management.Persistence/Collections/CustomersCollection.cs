using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using OrderManagement.Domain.Models;

namespace OrderManagement.Persistence.Collections
{
    public class CustomersCollection
    {
        public static IMongoCollection<Customer> Open()
        {
            var settings = MongoClientSettings.FromConnectionString("mongodb+srv://admin:admin@cluster0.aj7ss.mongodb.net/myFirstDatabase?retryWrites=true&w=majority");
            var client = new MongoClient(settings);
            var database = client.GetDatabase("OrderManagement");

            return database.GetCollection<Customer>("Customers");
        }
    }
}
