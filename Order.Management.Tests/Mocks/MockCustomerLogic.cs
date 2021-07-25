using System.Collections.Generic;
using Moq;
using OrderManagement.Domain.Models;
using OrderManagement.Services.BusinessLogic.Interfaces;

namespace OrderManagement.Tests.Mocks
{
    public class MockCustomerLogic : Mock<ICustomerLogic>
    {
        public MockCustomerLogic MockValidateRequiredCustomerFieldsTrue(Customer customer)
        {
            Setup(x => x.ValidateRequiredCustomerFields(customer)).ReturnsAsync(true);

            return this;
        }

        public MockCustomerLogic MockValidateRequiredCustomerFieldsFalse(Customer customer)
        {
            Setup(x => x.ValidateRequiredCustomerFields(customer)).ReturnsAsync(false);

            return this;
        }

        public MockCustomerLogic MockValidateCustomerEmailTrue(string mail, List<Customer> customers)
        {
            Setup(x => x.ValidateCustomerEmail(mail, customers)).ReturnsAsync(true);

            return this;
        }

        public MockCustomerLogic MockValidateCustomerEmailFalse(string mail, List<Customer> customers)
        {
            Setup(x => x.ValidateCustomerEmail(mail, customers)).ReturnsAsync(false);

            return this;
        }

        public MockCustomerLogic MockValidateCustomerPhoneTrue(string phone, List<Customer> customers)
        {
            Setup(x => x.ValidateCustomerPhone(phone, customers)).ReturnsAsync(true);

            return this;
        }

        public MockCustomerLogic MockValidateCustomerPhoneFalse(string phone, List<Customer> customers)
        {
            Setup(x => x.ValidateCustomerPhone(phone, customers)).ReturnsAsync(false);

            return this;
        }
    }
}
