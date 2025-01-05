using Sales.Businesslogic.Interface;
using Sales.Models;
using Sales.Repository;
using Sales.Repository.Interface;

namespace Sales.Businesslogic
{
    public class OrderBusinesslogic : IOrderbusinesslogic
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IProductRepository _productRepository;

        public OrderBusinesslogic (IOrderRepository orderRepository, ICustomerRepository customerRepository, IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _customerRepository = customerRepository;
            _productRepository = productRepository; 
        }
     
        public Order AddOrders(Order order)
        {

            var existingCustomer = _customerRepository.GetCustomer(order.CustomerID);
            if (existingCustomer == null)
            {
                throw new InvalidOperationException("Customer with the given CustomerID does not exist.");
            }

            var existingProduct = _productRepository.GetProduct(order.ProductID);
            if (existingProduct == null)
            {
                throw new InvalidOperationException("Product with the given ProductID does not exist.");
            }


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
