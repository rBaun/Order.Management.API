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
        Task<Customer> UpdateCustomerAddress(string address);
        Task<Customer> UpdateCustomerMail(string mail);
        Task<Customer> UpdateCustomerName(string name);
        Task<Customer> UpdateCustomerStatus(CustomerStatus status);
    }
}
