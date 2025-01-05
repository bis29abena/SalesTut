using Sales.Models;

namespace Sales.Repository.Interface
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAll();
        Category GetCategory(int id);
        void UpdateCategory(Category category);
        void AddCategory(Category category);
        void DeleteCategory(int id);
    }
}
