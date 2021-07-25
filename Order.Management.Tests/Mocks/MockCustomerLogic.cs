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
            Setup(x => x.HasRequiredCustomerFields(customer)).Returns(true);

            return this;
        }

        public MockCustomerLogic MockValidateRequiredCustomerFieldsFalse(Customer customer)
        {
            Setup(x => x.HasRequiredCustomerFields(customer)).Returns(false);

            return this;
        }

        public MockCustomerLogic MockValidateCustomerEmailTrue(string mail, List<Customer> customers)
        {
            Setup(x => x.HasExistingMail(mail, customers)).Returns(true);

            return this;
        }

        public MockCustomerLogic MockValidateCustomerEmailFalse(string mail, List<Customer> customers)
        {
            Setup(x => x.HasExistingMail(mail, customers)).Returns(false);

            return this;
        }

        public MockCustomerLogic MockValidateCustomerPhoneTrue(string phone, List<Customer> customers)
        {
            Setup(x => x.HasExistingPhone(phone, customers)).Returns(true);

            return this;
        }

        public MockCustomerLogic MockValidateCustomerPhoneFalse(string phone, List<Customer> customers)
        {
            Setup(x => x.HasExistingPhone(phone, customers)).Returns(false);

            return this;
        }
    }
}
