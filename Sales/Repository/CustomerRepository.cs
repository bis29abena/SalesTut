using Sales.Repository.Interface;
using Sales.Models;
using Sales.Data;

namespace Sales.Repository.Interface
{
        public class CustomerRepository : ICustomerRepository
        {
            private readonly AppDbContext _appDbContext;

            public CustomerRepository(AppDbContext appDbContext)
            {
                _appDbContext = appDbContext;
            }

            public void AddCustomer(Customer customer)
            {
                _appDbContext.Customer.Add(customer);
                _appDbContext.SaveChanges();
            }

            public void DeleteCustomer(int id)
            {
                var customer = _appDbContext.Customer.FirstOrDefault(customer => customer.CustomerID == id);

                if (customer != null)
                {
                    _appDbContext.Customer.Remove(customer);
                    _appDbContext.SaveChanges();
                }
            }

            public IEnumerable<Customer> GetAll()
            {
                return _appDbContext.Customer.ToList();
            }

            public Customer GetCustomer(int id)
            {
                return _appDbContext.Customer.FirstOrDefault(customer => customer.CustomerID == id);
            }

            public void UpdateCustomer(Customer customer)
            {
                var existingCustomer = _appDbContext.Customer.Find(customer.CustomerID);

                if (existingCustomer != null)
                {
                    existingCustomer.Firstname = customer.Firstname;
                    existingCustomer.Lastname = customer.Lastname;
                    existingCustomer.Email = customer.Email;
                    existingCustomer.Phonenumber = customer.Phonenumber;
                }
            }
        }
}
