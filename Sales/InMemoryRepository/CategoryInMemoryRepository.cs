using Sales.InMemoryRepository.Interface;
using Sales.Models;

namespace Sales.InMemoryRepository
{

        public class CategoryInMemoryRepository : ICategoryRepository
        {
           
            private readonly List<Category> categories;

            
            public CategoryInMemoryRepository()
            {
                categories = new List<Category>
            {
                new Category { CategoryID = 1, Name = "Electronics", Description = "Electronic devices and gadgets" },
                new Category { CategoryID = 2, Name = "Clothing", Description = "Men's and Women's apparel" },
                new Category { CategoryID = 3, Name = "Books", Description = "Books of all genres" }
            };
            }

            
            public IEnumerable<Category> GetAll()
            {
                return categories;
            }

           
            public Category GetCategory(int id)
            {
                return categories.FirstOrDefault(c => c.CategoryID == id);
            }

            public void AddCategory(Category category)
            {
                categories.Add(category);
            }

            public void UpdateCategory(Category category)
            {
                var existingCategory = GetCategory(category.CategoryID);
                if (existingCategory != null)
                {
                    existingCategory.Name = category.Name;
                    existingCategory.Description = category.Description;
                }
            }

            public void DeleteCategory(int id)
            {
                var categoryToDelete = GetCategory(id);
                if (categoryToDelete != null)
                {
                    categories.Remove(categoryToDelete); 
                }
            }
        }
   
}
