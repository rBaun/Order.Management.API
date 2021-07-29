using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderManagement.Domain.Wrappers.Common;

namespace OrderManagement.Application.UseCases.Customers.PATCH
{
    public interface IUpdateCustomerLastNameUseCase
    {
        Task<Response<string>> Execute(string customerId, string lastName);
    }
}
