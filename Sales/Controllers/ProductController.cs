using Microsoft.AspNetCore.Mvc;
using Sales.InMemoryRepository.Interface;
using Sales.Models;

namespace Sales.Controllers
{
    [Controller]
    [Route("product")]
    public class ProductController : Controller
    {
   
            private readonly IProductRepository _productRepository;

            public ProductController(IProductRepository productRepository)
            {
                _productRepository = productRepository;
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
                    return BadRequest();
                }

                _productRepository.AddProduct(product);
         
                return CreatedAtAction(nameof(GetProduct), new { id = product.ProductID }, product);
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

