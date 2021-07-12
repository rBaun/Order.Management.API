namespace OrderManagement.Domain.Enums
{
    public enum CustomerStatus
    {
        NoAccount = 0,
        Customer = 1,
        PurchasedOnce = 2,
        PurchasedMultiple = 3,
        Deactivated = 99
    }
}
