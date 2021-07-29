using System;
using System.Collections.Generic;
using OrderManagement.Domain.Models;
using OrderManagement.Services.CustomerUseCases.PUT;
using OrderManagement.Tests.Mocks;
using Xunit;

namespace OrderManagement.Tests.CustomerTests
{
    public class UpdateCustomerIntegrationTest : IDisposable
    {
        public UpdateCustomerIntegrationTest()
        {
            OldCustomer = new Customer
            {
                FirstName = "Rune",
                LastName = "Baun Andersen",
                Address = "Tordenskjoldsgade 10, st. tv",
                Mail = "runeb95@gmail.com",
                Phone = "27509331"
            };
            NewValidCustomer = new Customer
            {
                FirstName = "Enur",
                LastName = "Nuab nesredna",
                Address = "Tordenskjoldsgade 15, st. tv",
                Mail = "rba@gmail.com",
                Phone = "12341234"
            };
            NewInvalidCustomer = new Customer
            {
                FirstName = "Lucas",
                LastName = "Andersen",
                Address = "Tordenskjoldsgade 30, st. tv",
                Mail = "runeb95@gmail.com",
                Phone = "27509331"
            };
            Customers = new List<Customer>
            {
                OldCustomer
            };
        }

        public void Dispose()
        {
        }

        public Customer OldCustomer { get; set; }
        public Customer NewValidCustomer { get; set; }
        public Customer NewInvalidCustomer { get; set; }
        public List<Customer> Customers { get; set; }

        [Fact(DisplayName = "INTEGRATION: Update Customer - Valid Input")]
        public void UpdateExistingCustomer_InputsAllNewInformation_ShouldReturnUpdatedCustomer()
        {
            // Arrange
            var mockCustomerRepository = new MockCustomerRepository()
                .MockGetEntities(Customers)
                .MockUpdateCustomer(NewValidCustomer);

            var mockCustomerLogic = new MockCustomerLogic()
                .MockHasExistingMailFalse(NewValidCustomer.Mail, Customers)
                .MockHasExistingPhoneFalse(NewValidCustomer.Phone, Customers)
                .MockHasRequiredCustomerFieldsTrue(NewValidCustomer);

            var updateCustomerUseCase =
                new UpdateCustomerUseCase(mockCustomerRepository.Object, mockCustomerLogic.Object);

            // Act
            var result = updateCustomerUseCase.Execute(NewValidCustomer).Result;

            // Assert
            Assert.True(result.Errors.Count == 0);
        }

        [Fact(DisplayName = "INTEGRATION: Update Customer - Invalid Input")]
        public void UpdateExistingCustomer_InputsExistingMailAndPhone_ShouldReturnResponseWithError()
        {
            // Arrange
            var mockCustomerRepository = new MockCustomerRepository()
                .MockGetEntities(Customers)
                .MockUpdateCustomer(NewInvalidCustomer);

            var mockCustomerLogic = new MockCustomerLogic()
                .MockHasExistingMailTrue(NewInvalidCustomer.Mail, Customers)
                .MockHasExistingPhoneTrue(NewInvalidCustomer.Phone, Customers)
                .MockHasRequiredCustomerFieldsTrue(NewInvalidCustomer);

            var updateCustomerUseCase =
                new UpdateCustomerUseCase(mockCustomerRepository.Object, mockCustomerLogic.Object);

            // Act
            var result = updateCustomerUseCase.Execute(NewInvalidCustomer).Result;

            // Assert
            Assert.True(result.Errors.Count > 0);
        }
    }
}