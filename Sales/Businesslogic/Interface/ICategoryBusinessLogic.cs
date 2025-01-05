using Sales.Models;

namespace Sales.Businesslogic.Interface
{
    public interface ICategoryBusinessLogic
    {
        Category AddCategories(Category category);
        void UpdateCategories(Category category);
    }
}
