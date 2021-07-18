using System.Threading.Tasks;
using OrderManagement.Domain.Enums;
using OrderManagement.Domain.Models;

namespace OrderManagement.Services.BusinessLogic.Interfaces
{
    public interface ICustomerLogic
    {
        Task<bool> ValidateCustomerEmail(string email);
        Task<bool> ValidateCustomerPhone(string phone);
        Task<bool> ValidateRequiredCustomerFields(Customer customer);
    }
}
