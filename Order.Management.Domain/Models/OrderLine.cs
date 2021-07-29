namespace OrderManagement.Domain.Models
{
    public class OrderLine
    {
        public int OrderLineId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public double SubTotal { get; set; }

        public int OrderId { get; set; }
    }
}