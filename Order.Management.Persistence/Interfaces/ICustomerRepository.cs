using System.Collections.Generic;
using OrderManagement.Domain.Enums;
using OrderManagement.Domain.Models;

namespace OrderManagement.Persistence.Interfaces
{
    public interface ICustomerRepository : IEntityRepository<Customer>
    {
        List<Customer> GetFirstTimeCustomers();
        List<Customer> GetLoyalCustomers();
        List<Customer> GetNoAccountCustomers();
        Customer UpdateCustomerAddress(string address);
        Customer UpdateCustomerMail(string mail);
        Customer UpdateCustomerName(string name);
        Customer UpdateCustomerStatus(CustomerStatus status);
    }
}
