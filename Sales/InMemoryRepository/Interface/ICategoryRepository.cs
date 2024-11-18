using Sales.Models;

namespace Sales.InMemoryRepository.Interface
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAll();

        Category GetCategory(int id);

        void AddCategory(Category category);

        void UpdateCategory(Category category);

        void DeleteCategory(int id);
    }
}
