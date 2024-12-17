using Sales.Businesslogic.Interface;
using Sales.Models;
using Sales.Repository.Interface;

namespace Sales.Businesslogic
{
    public class OrderBusinesslogic : IOrderbusinesslogic
    {
        private readonly IOrderRepository _orderRepository;

        public OrderBusinesslogic (IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
     
        public Order AddOrders(Order order)
        {
            var orderRepository = _orderRepository.GetAll();
            if (orderRepository.Any()) 
            {
                var lastOrder = orderRepository.OrderByDescending(o => o.OrderID).FirstOrDefault();
                int lastOrdernumber = lastOrder.OrderID + 1;
                order.OrderID = lastOrdernumber;   
                
                
            }
            
            
            _orderRepository.AddOrder(order);
            return order;
         
            


        }
    }
}
