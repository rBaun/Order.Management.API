using System;
using System.Collections.Generic;
using OrderManagement.Domain.Enums;

namespace OrderManagement.Domain.Models
{
    public class Order
    {
        public Order()
        {
            OrderLines = new List<OrderLine>();
        }

        public string OrderId { get; set; }

        public DateTime PlacedOn { get; set; }
        public DateTime ProcessedOn { get; set; }
        public DateTime ShippedOn { get; set; }
        public string ShippedTo { get; set; }
        public string ShippedFrom { get; set; }

        public Customer Customer { get; set; }
        public List<OrderLine> OrderLines { get; set; }

        public double TotalPrice { get; set; }
        public OrderStatus OrderStatus { get; set; }
    }
}