using Microsoft.AspNetCore.Mvc;
using Sales.InMemoryRepository.Interface;
using Sales.Models;

namespace Sales.Controllers
{
    [Controller]
    [Route("customer")]
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet("getAll")]
        public ActionResult<IEnumerable<Customer>> GetAll()
        {
            var customers = _customerRepository.GetAll();

            return Ok(customers);
        }

        [HttpGet("getByID/{id}")]
        public ActionResult<Customer> GetCustomer([FromRoute] int id)
        {
            var customer = _customerRepository.GetCustomer(id);

            return Ok(customer);
        }

        [HttpPatch("update")]
        public ActionResult UpdateCustomer(Customer customer) 
        {
            _customerRepository.UpdateCustomer(customer);

            return Ok(customer);
        }

        [HttpPost("add")]
        public ActionResult AddCustomer([FromBody] Customer customer)
        {
            _customerRepository.AddCustomer(customer);
            return Ok(customer);
        }

        [HttpDelete("delete/{id}")]
        public ActionResult DeleteProduct([FromRoute] int id)
        {
            var product = _customerRepository.GetCustomer(id);
            if (product == null)
            {
                return NotFound();
            }

            _customerRepository.DeleteCustomer(id);
            return NoContent();
        }
    }

  
}
