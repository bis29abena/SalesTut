using Sales.Models;

namespace Sales.Businesslogic.Interface
{
    public interface ICustomerBusinessLogic
    {
        Customer AddCustomers (Customer customer);
        Customer UpdateCustomers (Customer customer); 
        void DeleteCustomers (int customerId);
    }
}