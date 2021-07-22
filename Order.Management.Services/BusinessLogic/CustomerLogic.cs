using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderManagement.Domain.Models;
using OrderManagement.Persistence.Interfaces;
using OrderManagement.Services.BusinessLogic.Interfaces;

namespace OrderManagement.Services.BusinessLogic
{
    public class CustomerLogic : ICustomerLogic
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerLogic(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<bool> ValidateCustomerEmail(string email, List<Customer> customers)
        {
            return customers.Count(customer =>
                       string.Equals(customer.Mail, email, StringComparison.CurrentCultureIgnoreCase)) == 0;
        }

        public async Task<bool> ValidateCustomerPhone(string phone, List<Customer> customers)
        {
            return customers.Count(customer =>
                       string.Equals(customer.Phone, phone, StringComparison.CurrentCultureIgnoreCase)) == 0;
        }

        public async Task<bool> ValidateRequiredCustomerFields(Customer customer)
        {
            if (customer.FirstName?.Length < 3 || string.IsNullOrWhiteSpace(customer.FirstName) 
                                              || customer.LastName?.Length < 3 
                                              || string.IsNullOrWhiteSpace(customer.LastName))
                return false;

            if (customer.Address?.Length < 3 || string.IsNullOrWhiteSpace(customer.Address))
                return false;

            if (customer.Mail?.Length < 3 || string.IsNullOrWhiteSpace(customer.Mail))
                return false;

            return true;
        }
    }
}
