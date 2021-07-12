using System;
using OrderManagement.Domain.Enums;

namespace OrderManagement.Domain.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public double Price { get; set; }
        public DateTime RestockedOn { get; set; }
        public ProductStatus ProductStatus { get; set; }
    }
}
