using Sales.Models;

namespace Sales.Repository.Interface
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetAll();
        Customer GetCustomer(int id);
        void UpdateCustomer(Customer customer);
        void AddCustomer(Customer customer);
        void DeleteCustomer(int id);
    }
}
