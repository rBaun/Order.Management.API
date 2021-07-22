using System.Collections.Generic;
using Moq;
using OrderManagement.Domain.Models;
using OrderManagement.Persistence.Interfaces;

namespace OrderManagement.Tests.Mocks
{
    public class MockCustomerRepository : Mock<ICustomerRepository>
    {
        public void MockCreateEntity(Customer customer)
        {
            Setup(x => x.CreateEntity(customer)).ReturnsAsync(customer);
        }

        public void MockGetEntities(List<Customer> customers)
        {
            Setup(x => x.GetEntities()).ReturnsAsync(customers);
        }
    }
}
