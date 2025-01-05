using Microsoft.AspNetCore.Mvc;
using Sales.Repository.Interface;
using Sales.Models;
using Sales.Businesslogic.Interface;
using Sales.Businesslogic;

namespace Sales.Controllers
{
    [Controller]
    [Route("customer")]
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ICustomerBusinessLogic _customerbusinesslogic;

        public CustomerController(ICustomerRepository customerRepository, ICustomerBusinessLogic customerbusinesslogic)
        {
            _customerRepository = customerRepository;
            _customerbusinesslogic = customerbusinesslogic;
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
        public ActionResult UpdateCustomer([FromBody]Customer customer) 
        {
            if (customer == null)
            {
                return BadRequest(new { message = "Customer object is null." });
            }

            try
            {
                var updatedCustomer = _customerbusinesslogic.UpdateCustomers(customer);
                return Ok(new { Message = "Customer updated successfully.", Customer = updatedCustomer });
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred.", Details = ex.Message });
            }
        }

        [HttpPost("add")]
        public ActionResult AddCustomer([FromBody] Customer customer)
        {
           var addedcustomer = _customerbusinesslogic.AddCustomers(customer);
            return Ok(addedcustomer);
        }
         
        [HttpDelete("{customerId}")]
        public ActionResult DeleteCustomer([FromRoute] int customerId)
        {
            try
            {
                _customerbusinesslogic.DeleteCustomers(customerId);


                return Ok(new { Message = "Customer deleted successfully." });
            }
            catch (InvalidOperationException ex)
            {

                return NotFound(new { Message = ex.Message });
            }
            catch (Exception ex)
            {

                return StatusCode(500, new { Message = "An error occurred while deleting the customer.", Details = ex.Message });
            }

        }
    }

  
}
