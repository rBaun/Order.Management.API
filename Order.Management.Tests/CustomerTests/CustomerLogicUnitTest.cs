using System;
using System.Collections.Generic;
using OrderManagement.Domain.Models;
using OrderManagement.Services.BusinessLogic;
using OrderManagement.Tests.Mocks;
using Xunit;

namespace OrderManagement.Tests.CustomerTests
{
    public class CustomerLogicUnitTest : IDisposable
    {
        public string ValidMail { get; set; }
        public string InvalidMail { get; set; }
        public string ValidPhone { get; set; }
        public string InvalidPhone { get; set; }
        public Customer CustomerWithValidDetails { get; set; }
        public Customer CustomerWithInvalidDetails { get; set; }
        public List<Customer> Customers { get; set; }

        public CustomerLogicUnitTest()
        {
            ValidMail = "jane_joe@janesdoe.com";
            InvalidMail = "existin@gmail.com";
            ValidPhone = "12312312";
            InvalidPhone = "88888888";
            CustomerWithValidDetails = new Customer
            {
                FirstName = "Jane",
                LastName = "Doe",
                Mail = "existin@gmail.com",
                Address = "janes ville 5",
                Phone = "88888888"
            };
            CustomerWithInvalidDetails = new Customer
            {
                Mail = "joey_banana@domain.com",
                LastName = "banana man"
            };
            Customers = new List<Customer>
            {
                CustomerWithValidDetails,
                CustomerWithInvalidDetails
            };
        }

        public void Dispose()
        {
            
        }

        [Fact(DisplayName = "UNIT: Validate Mail - Valid Input")]
        public void ValidateCustomerMail_InputsValidMail_ShouldReturnTrue()
        {
            // Arrange
            var validMail = ValidMail;
            var customers = Customers;
            var customerLogic = new CustomerLogic(new MockCustomerRepository().Object);

            // Act
            var result = customerLogic.HasExistingMail(validMail, customers);

            // Assert
            Assert.False(result);
        }

        [Fact(DisplayName = "UNIT: Validate Mail - Invalid Input")]
        public void ValidateCustomerMail_InputsExistingMail_ShouldReturnFalse()
        {
            // Arrange 
            var existingMail = InvalidMail;
            var customers = Customers;
            var customerLogic = new CustomerLogic(new MockCustomerRepository().Object);

            // Act
            var result = customerLogic.HasExistingMail(existingMail, customers);

            // Assert
            Assert.True(result);
        }

        [Fact(DisplayName = "UNIT: Validate Phone - Valid Input")]
        public void ValidateCustomerPhone_InputsValidPhone_ShouldReturnTrue()
        {
            // Arrange
            var validPhone = ValidPhone;
            var customers = Customers;
            var customerLogic = new CustomerLogic(new MockCustomerRepository().Object);

            // Act
            var result = customerLogic.HasExistingPhone(validPhone, customers);

            // Assert
            Assert.False(result);
        }

        [Fact(DisplayName = "UNIT: Validate Phone - Invalid Input")]
        public void ValidateCustomerPhone_InputsExistingPhone_ShouldReturnFalse()
        {
            // Arrange
            var existingPhone = InvalidPhone;
            var customers = Customers;
            var customerLogic = new CustomerLogic(new MockCustomerRepository().Object);

            // Act
            var result = customerLogic.HasExistingPhone(existingPhone, customers);

            // Assert
            Assert.True(result);
        }

        [Fact(DisplayName = "UNIT: Validate Customer Details - Valid Input")]
        public void ValidateCustomerDetails_InputsRequiredFields_ShouldReturnTrue()
        {
            // Arrange
            var validCustomer = CustomerWithValidDetails;
            var customerLogic = new CustomerLogic(new MockCustomerRepository().Object);

            // Act
            var result = customerLogic.HasRequiredCustomerFields(validCustomer);

            // Assert
            Assert.True(result);
        }

        [Fact(DisplayName = "UNIT: Validate Customer Details - Invalid Input")]
        public void ValidateCustomerDetails_InputsNotAllRequiredFields_ShouldReturnFalse()
        {
            // Arrange
            var invalidCustomer = CustomerWithInvalidDetails;
            var customerLogic = new CustomerLogic(new MockCustomerRepository().Object);

            // Act
            var result = customerLogic.HasRequiredCustomerFields(invalidCustomer);

            // Assert
            Assert.False(result);
        }
    }
}
