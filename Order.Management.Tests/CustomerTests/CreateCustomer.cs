using System;
using System.Collections.Generic;
using Xunit;
using Moq;
using OrderManagement.Domain.Models;
using OrderManagement.Persistence.Interfaces;
using OrderManagement.Services.BusinessLogic.Interfaces;
using OrderManagement.Services.CustomerUseCases;
using OrderManagement.Services.CustomerUseCases.POST;

namespace OrderManagement.Tests.CustomerTests
{
    public class CreateCustomer : IDisposable
    {
        private Customer CustomerWithRequiredFields { get; set; }
        private Customer CustomerWithoutRequiredFields { get; set; }
        private List<Customer> Customers { get; set; }

        public CreateCustomer()
        {
            CustomerWithRequiredFields = new Customer
            {
                FirstName = "Jane",
                LastName = "Doe",
                Mail = "jane_doe@mail.com",
                Address = "janes ville 5",
                Phone = "12312312"
            };

            CustomerWithoutRequiredFields = new Customer
            {
                Mail = "joey_banana@domain.com",
                LastName = "banana man"
            };

            Customers = new List<Customer>
            {
                CustomerWithRequiredFields,
                CustomerWithoutRequiredFields
            };
        }

        public void Dispose()
        {
           
        }

        [Fact(DisplayName = "INTEGRATION: Create Customer - Valid Input")]
        public void CreateCustomer_InputsValidCustomer_ShouldReturnCreatedCustomer()
        {
            // Arrange
            var customerRepository = new Mock<ICustomerRepository>();
            var customerLogic = new Mock<ICustomerLogic>();

            customerRepository.Setup(x => x.CreateEntity(CustomerWithRequiredFields)).ReturnsAsync(CustomerWithRequiredFields);
            customerRepository.Setup(x => x.GetEntities()).ReturnsAsync(Customers);

            customerLogic.Setup(x => x.ValidateRequiredCustomerFields(CustomerWithRequiredFields)).ReturnsAsync(true);
            customerLogic.Setup(x => x.ValidateCustomerEmail(CustomerWithRequiredFields.Mail, Customers)).ReturnsAsync(true);
            customerLogic.Setup(x => x.ValidateCustomerPhone(CustomerWithRequiredFields.Phone, Customers))
                .ReturnsAsync(true);

            var createCustomerUseCase = new CreateCustomerUseCase(customerLogic.Object, customerRepository.Object);
            var customerService = new CustomerService(createCustomerUseCase, null);

            // Act
            var createdCustomer = customerService.CreateCustomer(CustomerWithRequiredFields).Result;

            // Assert
            Assert.True(createdCustomer.Errors.Count == 0);
        }

        [Fact(DisplayName = "INTEGRATION: Create Customer - Invalid Input")]
        public void CreateCustomer_InputsInvalidCustomer_ShouldReturnErrorMessage()
        {
            // Arrange
            var customerRepository = new Mock<ICustomerRepository>();
            var customerLogic = new Mock<ICustomerLogic>();

            customerRepository.Setup(x => x.CreateEntity(CustomerWithoutRequiredFields)).ReturnsAsync(CustomerWithoutRequiredFields);
            customerRepository.Setup(x => x.GetEntities()).ReturnsAsync(Customers);

            customerLogic.Setup(x => x.ValidateRequiredCustomerFields(CustomerWithoutRequiredFields)).ReturnsAsync(false);
            customerLogic.Setup(x => x.ValidateCustomerEmail(CustomerWithoutRequiredFields.Mail, Customers)).ReturnsAsync(false);
            customerLogic.Setup(x => x.ValidateCustomerPhone(CustomerWithoutRequiredFields.Phone, Customers))
                .ReturnsAsync(true);

            var createCustomerUseCase = new CreateCustomerUseCase(customerLogic.Object, customerRepository.Object);
            var customerService = new CustomerService(createCustomerUseCase, null);

            // Act
            var createdCustomer = customerService.CreateCustomer(CustomerWithRequiredFields).Result;

            // Assert
            Assert.True(createdCustomer.Errors.Count > 0);
        }
    }
}
