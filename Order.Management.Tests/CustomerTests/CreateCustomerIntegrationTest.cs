using System;
using System.Collections.Generic;
using Xunit;
using OrderManagement.Domain.Models;
using OrderManagement.Services.CustomerUseCases.POST;
using OrderManagement.Tests.Mocks;

namespace OrderManagement.Tests.CustomerTests
{
    public class CreateCustomerIntegrationTest : IDisposable
    {
        private Customer CustomerWithRequiredFields { get; set; }
        private Customer CustomerWithoutRequiredFields { get; set; }
        private List<Customer> Customers { get; set; }

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

        [Fact(DisplayName = "INTEGRATION: Create Customer - Valid Input")]
        public void CreateCustomer_InputsValidCustomer_ShouldReturnCreatedCustomer()
        {
            // Arrange
            var mockCustomerRepository = new MockCustomerRepository()
                .MockCreateEntity(CustomerWithRequiredFields)
                .MockGetEntities(Customers);

            var mockCustomerLogic = new MockCustomerLogic()
                .MockValidateCustomerEmailTrue(CustomerWithRequiredFields.Mail, Customers)
                .MockValidateCustomerPhoneTrue(CustomerWithRequiredFields.Phone, Customers)
                .MockValidateRequiredCustomerFieldsTrue(CustomerWithRequiredFields);

            var createCustomerUseCase = new CreateCustomerUseCase(mockCustomerLogic.Object, mockCustomerRepository.Object);

            // Act
            var result = createCustomerUseCase.Execute(CustomerWithRequiredFields).Result;

            // Assert
            Assert.True(result.Errors.Count == 0);
        }

        [Fact(DisplayName = "INTEGRATION: Create Customer - Invalid Input")]
        public void CreateCustomer_InputsInvalidCustomer_ShouldReturnErrorMessage()
        {
            // Arrange
            var mockCustomerRepository = new MockCustomerRepository();
            mockCustomerRepository.MockCreateEntity(CustomerWithRequiredFields);
            mockCustomerRepository.MockGetEntities(Customers);

            var mockCustomerLogic = new MockCustomerLogic();
            mockCustomerLogic.MockValidateCustomerEmailFalse(CustomerWithRequiredFields.Mail, Customers);
            mockCustomerLogic.MockValidateCustomerPhoneFalse(CustomerWithRequiredFields.Phone, Customers);
            mockCustomerLogic.MockValidateRequiredCustomerFieldsFalse(CustomerWithRequiredFields);

            var createCustomerUseCase = new CreateCustomerUseCase(mockCustomerLogic.Object, mockCustomerRepository.Object);

            // Act
            var result = createCustomerUseCase.Execute(CustomerWithRequiredFields).Result;

            // Assert
            Assert.True(result.Errors.Count > 0);
        }
    }
}
