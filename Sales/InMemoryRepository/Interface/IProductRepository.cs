using Sales.Models;

namespace Sales.InMemoryRepository.Interface
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        Product GetProduct(int id);
        void UpdateProduct(Product product);
        void AddProduct(Product product);
        void DeleteProduct(int id);
    }
}
