using System.Collections.Generic;
using Moq;
using OrderManagement.Domain.Models;
using OrderManagement.Persistence.Interfaces;

namespace OrderManagement.Tests.Mocks
{
    public class MockCustomerRepository : Mock<ICustomerRepository>
    {
        public MockCustomerRepository MockCreateEntity(Customer customer)
        {
            Setup(x => x.CreateEntity(customer)).ReturnsAsync(customer);

            return this;
        }

        public MockCustomerRepository MockGetEntities(List<Customer> customers)
        {
            Setup(x => x.GetEntities()).ReturnsAsync(customers);

            return this;
        }

        public MockCustomerRepository MockGetEntityById(Customer customer)
        {
            Setup(x => x.GetEntityById(customer.CustomerId)).ReturnsAsync(customer);

            return this;
        }

        public MockCustomerRepository MockUpdateCustomer(Customer customer)
        {
            Setup(x => x.UpdateEntity(customer)).ReturnsAsync(customer);

            return this;
        }
    }
}
