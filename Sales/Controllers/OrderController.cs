using Microsoft.AspNetCore.Mvc;
using Sales.Repository.Interface;
using Sales.Models;
using Sales.Businesslogic.Interface;

namespace Sales.Controllers
{
        [Controller]
        [Route("order")]
        public class OrderController : Controller
        {
            private readonly IOrderRepository _orderRepository;
            private readonly IOrderbusinesslogic _orderbusinesslogic;

            public OrderController(IOrderRepository orderRepository, IOrderbusinesslogic orderbusinesslogic)
            {
               _orderRepository = orderRepository;
               _orderbusinesslogic = orderbusinesslogic;
            }

            [HttpGet("getAll")]
            public ActionResult<IEnumerable<Order>> GetAll()
            {
                var orders = _orderRepository.GetAll();

                return Ok(orders);
            }

            [HttpGet("getByID/{id}")]
            public ActionResult<Order> GetOrder([FromRoute] int id)
            {
                var order = _orderRepository.GetOrder(id);

                return Ok(order);
            }

            [HttpPatch("update")]
            public ActionResult UpdateOrder(Order order)
            {
               _orderRepository.UpdateOrder(order);

                return Ok(order);
            }

            [HttpPost("add")]
            public ActionResult AddOrder([FromBody] Order order)
            {
               var addedOrder = _orderbusinesslogic.AddOrders(order);

                return Ok(addedOrder);
            }

            [HttpDelete("delete/{id}")]
            public ActionResult DeleteProduct([FromRoute] int id)
            {
                var product = _orderRepository.GetOrder(id);
                if (product == null)
                {
                    return NotFound();
                }

                _orderRepository.DeleteOrder(id);
                return NoContent();
            }
        }
    
}
