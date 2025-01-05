using Sales.Data;
using Sales.Models;
using Sales.Repository.Interface;

namespace Sales.Repository
{
    public class CategoryRepository : ICategoryRepository
    {

       private readonly AppDbContext _appDbContext;

        public CategoryRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void AddCustomer(Category category)
        {
            _appDbContext.Category.Add(category);
            _appDbContext.SaveChanges();
        }


        public IEnumerable<Category> GetAll()
        {
            return _appDbContext.Category.ToList();
        }


        public Category GetCategory(int id)
        {
            return _appDbContext.Category.FirstOrDefault(category => category.CategoryID == id);
        }

        public void AddCategory(Category category)
        {
            _appDbContext.Category.Add(category);
            _appDbContext.SaveChanges();
        }

        public void UpdateCategory(Category category)
        {
            var existingCategory = _appDbContext.Category.Find(category.CategoryID);
            if (existingCategory != null)
            {
                existingCategory.Name = category.Name;
                existingCategory.Description = category.Description;
            }
        }

        public void DeleteCategory(int id)
        {
            var category = _appDbContext.Category.FirstOrDefault(category => category.CategoryID == id);
            if (category != null)
            {
                _appDbContext.Category.Remove(category);
                _appDbContext.SaveChanges();
            }
        }

    }
}

