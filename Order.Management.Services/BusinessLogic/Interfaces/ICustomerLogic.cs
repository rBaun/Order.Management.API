using System.Collections.Generic;
using System.Threading.Tasks;
using OrderManagement.Domain.Models;

namespace OrderManagement.Services.BusinessLogic.Interfaces
{
    public interface ICustomerLogic
    {
        Task<bool> ValidateCustomerEmail(string email, List<Customer> customers);
        Task<bool> ValidateCustomerPhone(string phone, List<Customer> customers);
        Task<bool> ValidateRequiredCustomerFields(Customer customer);
    }
}
