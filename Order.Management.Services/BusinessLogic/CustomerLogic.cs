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

        public bool HasExistingMail(string email, List<Customer> customers)
        {
            return customers.Exists(customer =>
                       string.Equals(customer.Mail, email, StringComparison.CurrentCultureIgnoreCase));
        }

        public bool HasExistingPhone(string phone, List<Customer> customers)
        {
            return customers.Exists(customer =>
                       string.Equals(customer.Phone, phone, StringComparison.CurrentCultureIgnoreCase));
        }

        public bool HasRequiredCustomerFields(Customer customer)
        {
            if (customer.FirstName?.Length < 3 || string.IsNullOrWhiteSpace(customer.FirstName) 
                                              || customer.LastName?.Length < 3 
                                              || string.IsNullOrWhiteSpace(customer.LastName))
                return false;

            if (!HasValidAddress(customer.Address))
                return false;

            if (customer.Mail?.Length < 3 || string.IsNullOrWhiteSpace(customer.Mail))
                return false;

            return true;
        }

        public bool HasValidAddress(string address)
        {
            if (string.IsNullOrWhiteSpace(address))
                return false;

            if (address.Length < 3)
                return false;

            return true;
        }
    }
}
