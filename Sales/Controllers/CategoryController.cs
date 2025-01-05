using Microsoft.AspNetCore.Mvc;
using Sales.Repository.Interface;
using Sales.Models;
using Sales.Businesslogic.Interface;

namespace Sales.Controllers
{
    [Controller]
    [Route("category")]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICategoryBusinessLogic _categoryBusinessLogic;

        public CategoryController(ICategoryRepository categoryRepository, ICategoryBusinessLogic categoryBusinessLogic)
        {
            _categoryRepository = categoryRepository;
            _categoryBusinessLogic = categoryBusinessLogic;
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
                return BadRequest(new { Message = "Category object cannot be null." });
            }

            try
            {
                var addedCategory = _categoryBusinessLogic.AddCategories(category);

                return Ok(new { Message = "Category added successfully.", Category = addedCategory });
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while adding the category.", Details = ex.Message });
            }
        }

        [HttpPatch("update")]
        public ActionResult UpdateCategory(Category category) 
        {
            if (category == null)
            {
                return BadRequest(new { Message = "Category object cannot be null." });
            }

            try
            {
                _categoryBusinessLogic.UpdateCategories(category);

                return Ok(new { Message = "Category updated successfully.", Category = category });
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while updating the category.", Details = ex.Message });
            }
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
