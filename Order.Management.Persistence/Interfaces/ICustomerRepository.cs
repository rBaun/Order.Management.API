using System.Collections.Generic;
using System.Threading.Tasks;
using OrderManagement.Domain.Enums;
using OrderManagement.Domain.Models;

namespace OrderManagement.Persistence.Interfaces
{
    public interface ICustomerRepository : IEntityRepository<Customer>
    {
        Task<List<Customer>> GetFirstTimeCustomers();
        Task<List<Customer>> GetLoyalCustomers();
        Task<List<Customer>> GetNoAccountCustomers();
        Task<string> UpdateCustomerAddress(string customerId, string address);
        Task<string> UpdateCustomerMail(string customerId, string mail);
        Task<string> UpdateCustomerFirstName(string customerId, string firstName);
        Task<string> UpdateCustomerLastName(string customerId, string name);
        Task<CustomerStatus> UpdateCustomerStatus(string customerId, CustomerStatus status);
    }
}