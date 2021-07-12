namespace OrderManagement.Domain.Enums
{
    public enum OrderStatus
    {
        Received = 0,
        Processing = 1,
        Shipped = 2,
        Returned = 10,
        Cancelled = 99
    }
}
