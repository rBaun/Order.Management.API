using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using OrderManagement.Domain.Models;
using OrderManagement.Services.BusinessLogic.Interfaces;

namespace OrderManagement.Tests.Mocks
{
    public class MockCustomerLogic : Mock<ICustomerLogic>
    {
        public void MockValidateRequiredCustomerFieldsTrue(Customer customer)
        {
            Setup(x => x.ValidateRequiredCustomerFields(customer)).ReturnsAsync(true);
        }

        public void MockValidateRequiredCustomerFieldsFalse(Customer customer)
        {
            Setup(x => x.ValidateRequiredCustomerFields(customer)).ReturnsAsync(false);
        }

        public void MockValidateCustomerEmailTrue(string mail, List<Customer> customers)
        {
            Setup(x => x.ValidateCustomerEmail(mail, customers)).ReturnsAsync(true);
        }

        public void MockValidateCustomerEmailFalse(string mail, List<Customer> customers)
        {
            Setup(x => x.ValidateCustomerEmail(mail, customers)).ReturnsAsync(false);
        }

        public void MockValidateCustomerPhoneTrue(string phone, List<Customer> customers)
        {
            Setup(x => x.ValidateCustomerPhone(phone, customers)).ReturnsAsync(true);
        }

        public void MockValidateCustomerPhoneFalse(string phone, List<Customer> customers)
        {
            Setup(x => x.ValidateCustomerPhone(phone, customers)).ReturnsAsync(false);
        }
    }
}
