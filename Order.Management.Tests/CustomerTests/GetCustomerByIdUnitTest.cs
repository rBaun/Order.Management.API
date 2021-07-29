using System;
using OrderManagement.Domain.Enums;
using OrderManagement.Domain.Models;
using OrderManagement.Services.CustomerUseCases.GET;
using OrderManagement.Tests.Mocks;
using Xunit;

namespace OrderManagement.Tests.CustomerTests
{
    public class GetCustomerByIdUnitTest : IDisposable
    {
        public GetCustomerByIdUnitTest()
        {
            ExistingCustomer = new Customer
            {
                CustomerId = "60faf44bef9600b01a8dff01",
                FirstName = "Bentley",
                LastName = "Montoya",
                Address = "667 Bragg Street, Mulino, Wisconsin, 221",
                Mail = "bentleymontoya@dreamia.com",
                Phone = "(909) 567-3581",
                CustomerStatus = CustomerStatus.NoAccount
            };
        }

        public void Dispose()
        {
        }

        public Customer ExistingCustomer { get; set; }

        [Fact(DisplayName = "UNIT: Get Customer By Id - Valid Input")]
        public void GetCustomerById_InputsExistingId_ShouldReturnFoundCustomer()
        {
            // Arrange
            var mockCustomerRepository = new MockCustomerRepository()
                .MockGetEntityById(ExistingCustomer);

            var getCustomerByIdUseCase = new GetCustomerByIdUseCase(mockCustomerRepository.Object);

            // Act
            var result = getCustomerByIdUseCase.Execute(ExistingCustomer.CustomerId).Result;

            // Assert
            Assert.True(result.Errors.Count == 0);
        }

        [Fact(DisplayName = "UNIT: Get Customer By Id - Invalid Input")]
        public void GetCustomerById_InputsNonExistingId_ShouldReturnErrorMessage()
        {
            // Arrange
            var mockCustomerRepository = new MockCustomerRepository()
                .MockGetEntityById(new Customer());

            var getCustomerByIdUseCase = new GetCustomerByIdUseCase(mockCustomerRepository.Object);

            // Act
            var result = getCustomerByIdUseCase.Execute("non existing id goes here").Result;

            // Assert
            Assert.True(result.Errors.Count > 0);
        }
    }
}