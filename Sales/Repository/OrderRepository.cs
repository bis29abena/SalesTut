using Sales.Data;
using Sales.Repository.Interface;
using Sales.Models;

namespace Sales.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _appDbContext;

        public OrderRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void AddOrder(Order order)
        { 
            _appDbContext.Order.Add(order);
            _appDbContext.SaveChanges();
        }

        public void DeleteOrder(int id)
        {
            var order = _appDbContext.Order.FirstOrDefault(order => order.OrderID == id);

            if (order != null)
            {
                _appDbContext.Order.Remove(order);
                _appDbContext.SaveChanges();
            }
        }

        public IEnumerable<Order> GetAll()
        {
            return _appDbContext.Order.ToList();
        }

        public Order GetOrder(int id)
        {
            return _appDbContext.Order.FirstOrDefault(order => order.OrderID == id);

        }

        public void UpdateOrder(Order order)
        {
            var existingOrder = _appDbContext.Order.Find(order.OrderID);

            if (existingOrder != null)
            {
                existingOrder.OrderDate = order.OrderDate;
                existingOrder.OrderStatus = order.OrderStatus;
                existingOrder.TotalAmount = order.TotalAmount;
            }
        }

    }
}
