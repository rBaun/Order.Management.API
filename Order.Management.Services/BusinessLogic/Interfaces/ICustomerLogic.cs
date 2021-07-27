using System.Collections.Generic;
using System.Threading.Tasks;
using OrderManagement.Domain.Models;

namespace OrderManagement.Services.BusinessLogic.Interfaces
{
    public interface ICustomerLogic
    {
        bool HasExistingMail(string email, List<Customer> customers);
        bool HasExistingPhone(string phone, List<Customer> customers); 
        bool HasRequiredCustomerFields(Customer customer);
        bool HasValidAddress(string address);
    }
}
