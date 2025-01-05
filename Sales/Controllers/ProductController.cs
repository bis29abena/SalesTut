using Microsoft.AspNetCore.Mvc;
using Sales.Repository.Interface;
using Sales.Models;
using Sales.Businesslogic.Interface;


namespace Sales.Controllers
{
    [Controller]
    [Route("product")]
    public class ProductController : Controller
    {
   
            private readonly IProductRepository _productRepository;
            private readonly IProductBusinessLogic _productBusinessLogic;

            public ProductController(IProductRepository productRepository, IProductBusinessLogic productBusinesLogic)
            {
                _productRepository = productRepository;
                _productBusinessLogic = productBusinesLogic;
                

            }

            [HttpGet("getAll")]
            public ActionResult<IEnumerable<Product>> GetAll()
            {
                var products = _productRepository.GetAll();
                return Ok(products); 
            }

            [HttpGet("getByID/{id}")]
            public ActionResult<Product> GetProduct([FromRoute] int id)
            {
                var product = _productRepository.GetProduct(id);
                if (product == null)
                {
                    return NotFound();
                }

                return Ok(product);  
            }

            [HttpPatch("update")]
            public ActionResult UpdateProduct([FromBody] Product product)
            {
                if (product == null)
                {
                    return BadRequest();
                }

                _productRepository.UpdateProduct(product);
                return Ok(product); 
            }

        [HttpPost("add")]
        public ActionResult AddProduct([FromBody] Product product)
        {
            if (product == null)
            {
                return BadRequest(new { Message = "Product object cannot be null." });
            }

            try
            {
                var addedProduct = _productBusinessLogic.AddProducts(product);
                return Ok(new { Message = "Product added successfully.", Product = addedProduct });
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { Message = ex.Message });
            }
            catch (Exception ex)
            { 
            return StatusCode(500, new { Message = "An error occurred while adding the product.", Details = ex.Message }); 

            }
        }


            [HttpDelete("delete/{id}")]
            public ActionResult DeleteProduct([FromRoute] int id)
            {
                var product = _productRepository.GetProduct(id);
                if (product == null)
                {
                    return NotFound();
                }

                _productRepository.DeleteProduct(id);
                return NoContent(); 
            }
        
    }
}

