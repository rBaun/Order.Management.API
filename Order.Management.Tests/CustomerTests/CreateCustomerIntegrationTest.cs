using System;
using System.Collections.Generic;
using OrderManagement.Domain.Models;
using OrderManagement.Services.CustomerUseCases.POST;
using OrderManagement.Tests.Mocks;
using Xunit;

namespace OrderManagement.Tests.CustomerTests
{
    public class CreateCustomerIntegrationTest : IDisposable
    {
        public CreateCustomerIntegrationTest()
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

        private Customer CustomerWithRequiredFields { get; }
        private Customer CustomerWithoutRequiredFields { get; }
        private List<Customer> Customers { get; }

        [Fact(DisplayName = "INTEGRATION: Create Customer - Invalid Input")]
        public void CreateCustomer_InputsInvalidCustomer_ShouldReturnErrorMessage()
        {
            // Arrange
            var mockCustomerRepository = new MockCustomerRepository()
                .MockCreateEntity(CustomerWithRequiredFields)
                .MockGetEntities(Customers);

            var mockCustomerLogic = new MockCustomerLogic()
                .MockHasExistingMailTrue(CustomerWithRequiredFields.Mail, Customers)
                .MockHasExistingPhoneTrue(CustomerWithRequiredFields.Phone, Customers)
                .MockHasRequiredCustomerFieldsFalse(CustomerWithRequiredFields);

            var createCustomerUseCase =
                new CreateCustomerUseCase(mockCustomerLogic.Object, mockCustomerRepository.Object);

            // Act
            var result = createCustomerUseCase.Execute(CustomerWithRequiredFields).Result;

            // Assert
            Assert.True(result.Errors.Count > 0);
        }

        [Fact(DisplayName = "INTEGRATION: Create Customer - Valid Input")]
        public void CreateCustomer_InputsValidCustomer_ShouldReturnCreatedCustomer()
        {
            // Arrange
            var mockCustomerRepository = new MockCustomerRepository()
                .MockCreateEntity(CustomerWithRequiredFields)
                .MockGetEntities(Customers);

            var mockCustomerLogic = new MockCustomerLogic()
                .MockHasExistingMailFalse(CustomerWithRequiredFields.Mail, Customers)
                .MockHasExistingPhoneFalse(CustomerWithRequiredFields.Phone, Customers)
                .MockHasRequiredCustomerFieldsTrue(CustomerWithRequiredFields);

            var createCustomerUseCase =
                new CreateCustomerUseCase(mockCustomerLogic.Object, mockCustomerRepository.Object);

            // Act
            var result = createCustomerUseCase.Execute(CustomerWithRequiredFields).Result;

            // Assert
            Assert.True(result.Errors.Count == 0);
        }
    }
}