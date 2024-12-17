using Sales.Models;

namespace Sales.Repository.Interface
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetAll();
        Order GetOrder(int id);
        void AddOrder(Order order);
        void UpdateOrder(Order order);
        void DeleteOrder(int id);
    }
}
