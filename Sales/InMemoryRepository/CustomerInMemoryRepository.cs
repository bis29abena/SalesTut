using Sales.InMemoryRepository.Interface;
using Sales.Models;

namespace Sales.InMemoryRepository
{
    public class CustomerInMemoryRepository : ICustomerRepository
    {
        private readonly List<Customer> customers;


        public CustomerInMemoryRepository()
        { 
            customers = new List<Customer>
            {
                new Customer{CustomerID = 1, Firstname = "Bismark", Lastname = "Osei", Email = "b@gmail.com", Phonenumber="0244161238"},
                new Customer{CustomerID = 2, Firstname = "Samuel", Lastname = "Ntim", Email = "s@gmail.com", Phonenumber="0591890483"}
            };
        }

        public void AddCustomer(Customer customer)
        {
            customers.Add(customer);
        }

        public void DeleteCustomer(int id)
        {
            Customer getCustomer = GetCustomer(id);

            customers.Remove(getCustomer);
        }

        public IEnumerable<Customer> GetAll()
        {
            return customers;
        }

        public Customer GetCustomer(int id)
        {
            return customers.FirstOrDefault(customer => customer.CustomerID == id);

        }

        public void UpdateCustomer(Customer customer)
        {
            Customer updateCustomer = GetCustomer(customer.CustomerID);

            if (updateCustomer == null)
            {
                throw new Exception("Customer not found.");

            }

            updateCustomer.Firstname = customer.Firstname;
            updateCustomer.Lastname = customer.Lastname; 
            updateCustomer.Email = customer.Email;
            updateCustomer.Phonenumber = customer.Phonenumber;
        }
    }
}
