using Sales.Businesslogic.Interface;
using Sales.Models;
using Sales.Repository.Interface;
using System.ComponentModel.DataAnnotations;

namespace Sales.Businesslogic
{ 

   public class CustomerBusinessLogic : ICustomerBusinessLogic
   {
        private readonly ICustomerRepository _customerRepository;

        public CustomerBusinessLogic(ICustomerRepository customerRepository)
        {

            _customerRepository = customerRepository;
        }
        public Customer AddCustomers(Customer customer)
        {
            if (!IsValidEmail(customer.Email))
            {
                throw new ArgumentException("Invalid email format.");
            }

            if (customer.Phonenumber.Length != 10 || !customer.Phonenumber.All(char.IsDigit))
            {
                throw new ArgumentException("Telephone number must be exactly 10 digits.");
            }
            var customerRepository = _customerRepository.GetAll();
            if (customerRepository.Any())
            {
                var lastCustomer = customerRepository.OrderByDescending(c => c.CustomerID).FirstOrDefault();
                int lastCustomerID = lastCustomer.CustomerID + 1;
                customer.CustomerID = lastCustomerID;
            }

            _customerRepository.AddCustomer(customer);
            return customer;

        }
        private bool IsValidEmail(string email)
        {
            var emailAddress = new EmailAddressAttribute();
            return emailAddress.IsValid(email);
        }

        public Customer UpdateCustomers(Customer customer)
        {
            if (string.IsNullOrWhiteSpace(customer.Firstname))
            {
                throw new InvalidOperationException("First name cannot be empty.");
            }

            if (string.IsNullOrWhiteSpace(customer.Lastname))
            {
                throw new InvalidOperationException("Last name cannot be empty.");
            }

            customer.Email = customer.Email?.Trim();
            customer.Phonenumber = customer.Phonenumber?.Trim();

            var existingCustomerWithEmail = _customerRepository.GetAll().FirstOrDefault(c => c.Email.Trim() == customer.Email && c.CustomerID != customer.CustomerID);

            var existingCustomerWithPhone = _customerRepository.GetAll().FirstOrDefault(c => c.Phonenumber.Trim() == customer.Phonenumber.Trim() && c.CustomerID != customer.CustomerID);

            if (existingCustomerWithEmail != null && existingCustomerWithPhone != null)
            {
                throw new InvalidOperationException(
                    "Both the provided email and phone number are already in use by other customers.");
            }

            if (existingCustomerWithEmail != null)
            {
                throw new InvalidOperationException("The provided email is already in use by another customer.");
            }

            if (existingCustomerWithPhone != null)
            {
                throw new InvalidOperationException("The provided phone number is already in use by another customer.");
            }

            _customerRepository.UpdateCustomer(customer);

            return customer;
        }

        public void DeleteCustomers(int customerId)
        {
            var customer = _customerRepository.GetCustomer(customerId);

            if (customer == null)
            {
               
                throw new InvalidOperationException($"Customer with ID {customerId} does not exist.");
            }

            _customerRepository.DeleteCustomer(customerId);
        }
    }
}
