using Sales.Businesslogic.Interface;
using Sales.Models;
using Sales.Repository;
using Sales.Repository.Interface;

namespace Sales.Businesslogic
{
    public class CategoryBusinessLogic : ICategoryBusinessLogic
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryBusinessLogic(ICategoryRepository categoryRepository)

        {
            _categoryRepository = categoryRepository;
        }


        public Category AddCategories(Category category)
        {
            string normalizedcategoryName = category.Name.Trim().ToLower();

            var existingCategory = _categoryRepository.GetAll()
                .FirstOrDefault(c => c.Name.Trim().ToLower() == normalizedcategoryName);

            if (existingCategory != null)
            {
                throw new InvalidOperationException("A category with the same name already exists.");
            }

            var categoryRepository = _categoryRepository.GetAll();
            if (categoryRepository.Any())
            {
                var lastOrder = categoryRepository.OrderByDescending(c => c.CategoryID).FirstOrDefault();
                int lastOrdernumber = lastOrder.CategoryID + 1;
                category.CategoryID = lastOrdernumber;
            }


            _categoryRepository.AddCategory(category);
            return category;
        }

        public void UpdateCategories(Category category)
        {
            if (string.IsNullOrEmpty(category.Name))
            {
                throw new InvalidOperationException("category name cannot be empty");
            }

            string categoryName = category.Name.Trim().ToLower();
            var existingCategory = _categoryRepository.GetAll().FirstOrDefault(c => c.Name.Trim().ToLower() == categoryName);

            if (existingCategory != null)
            {
                throw new InvalidOperationException("The category already exists");
            }

            _categoryRepository.UpdateCategory(category);
           
        }
    }
}
