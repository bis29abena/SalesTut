using Microsoft.AspNetCore.Mvc;
using Sales.InMemoryRepository.Interface;
using Sales.Models;

namespace Sales.Controllers
{
    [Controller]
    [Route("category")]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet("getAll")]
        public ActionResult<IEnumerable<Category>> GetAll()
        {
            var category = _categoryRepository.GetAll();

            return Ok(category);
        }

        [HttpGet("getByID/{id}")]
        public ActionResult<Category> GetCategory(int id)
        {
            var category = _categoryRepository.GetCategory(id);
            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        [HttpPost("add")]
        public ActionResult AddCategory(Category category)
        {
            if (category == null) 
            { 
             return BadRequest();
            }
            _categoryRepository.AddCategory(category);

            return Ok(category);
        }

        [HttpPatch("update")]
        public ActionResult UpdateCategory(Category category) 
        {
            if (category == null)
            {
                return BadRequest();
            }
            _categoryRepository.UpdateCategory(category);

            return Ok(category);
        }

        [HttpDelete("delete/{id}")]
        public ActionResult DeleteCategory(int id) 
        {
            var category = _categoryRepository.GetCategory(id);
            if (category == null)
            {
                return NotFound();
            }

            _categoryRepository.DeleteCategory(id);

            return NoContent();
        }
    }  

}
