using System;
using System.Collections.Generic;
using System.Net.Mail;
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
            if (!HasValidFirstName(customer.FirstName))
                return false;

            if (!HasValidLastName(customer.LastName))
                return false;

            if (!HasValidAddress(customer.Address))
                return false;

            if (!HasValidMail(customer.Mail))
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

        public bool HasValidMail(string mail)
        {
            try
            {
                var mailAddress = new MailAddress(mail);
                return mailAddress.Address == mail;
            }
            catch
            {
                return false;
            }
        }

        public bool HasValidFirstName(string firstName)
        {
            return firstName.Length >= 2 || string.IsNullOrWhiteSpace(firstName);
        }

        public bool HasValidLastName(string lastName)
        {
            return lastName.Length >= 2 || string.IsNullOrWhiteSpace(lastName);
        }
    }
}