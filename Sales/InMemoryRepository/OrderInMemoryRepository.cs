using Sales.InMemoryRepository.Interface;
using Sales.Models;
using System.ComponentModel;

namespace Sales.InMemoryRepository
{
    public class OrderInMemoryRepository : IOrderRepository
    {
        private readonly List<Order> orders;


        public OrderInMemoryRepository()
        {
            orders = new List<Order>
            {
                new Order{OrderID = 1, CustomerID = 1, OrderDate = new DateTime(2024, 10, 1), OrderStatus = "completed", TotalAmount = 1000 },
                new Order{OrderID = 2, CustomerID = 2, OrderDate = new DateTime(2024, 10, 20), OrderStatus = "Pending", TotalAmount = 900 },
                new Order{OrderID = 3, CustomerID = 3, OrderDate = new DateTime(2024, 11, 5), OrderStatus = "Pending", TotalAmount = 1500 },
               
            };
        }

        public void AddOrder(Order order)
        {
            orders.Add(order);
        }

        public void DeleteOrder(int id)
        {
            Order getOrder = GetOrder(id);

            orders.Remove(getOrder);
        }

        public IEnumerable<Order> GetAll()
        {
            return orders;
        }

        public Order GetOrder(int id)
        {
            return orders.FirstOrDefault(order => order.OrderID == id);

        }

        public void UpdateOrder(Order order)
        {
            Order updateOrder = GetOrder(order.OrderID);

            if (updateOrder == null)
            {
                throw new Exception("Order not found.");

            }

            updateOrder.OrderDate = order.OrderDate;
            updateOrder.OrderStatus = order.OrderStatus;
            updateOrder.TotalAmount = order.TotalAmount;
        
        }
    }
}
