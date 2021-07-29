using System.Collections.Generic;
using Moq;
using OrderManagement.Domain.Models;
using OrderManagement.Services.BusinessLogic.Interfaces;

namespace OrderManagement.Tests.Mocks
{
    public class MockCustomerLogic : Mock<ICustomerLogic>
    {
        public MockCustomerLogic MockHasRequiredCustomerFieldsTrue(Customer customer)
        {
            Setup(x => x.HasRequiredCustomerFields(customer)).Returns(true);

            return this;
        }

        public MockCustomerLogic MockHasRequiredCustomerFieldsFalse(Customer customer)
        {
            Setup(x => x.HasRequiredCustomerFields(customer)).Returns(false);

            return this;
        }

        public MockCustomerLogic MockHasExistingMailTrue(string mail, List<Customer> customers)
        {
            Setup(x => x.HasExistingMail(mail, customers)).Returns(true);

            return this;
        }

        public MockCustomerLogic MockHasExistingMailFalse(string mail, List<Customer> customers)
        {
            Setup(x => x.HasExistingMail(mail, customers)).Returns(false);

            return this;
        }

        public MockCustomerLogic MockHasExistingPhoneTrue(string phone, List<Customer> customers)
        {
            Setup(x => x.HasExistingPhone(phone, customers)).Returns(true);

            return this;
        }

        public MockCustomerLogic MockHasExistingPhoneFalse(string phone, List<Customer> customers)
        {
            Setup(x => x.HasExistingPhone(phone, customers)).Returns(false);

            return this;
        }
    }
}