using Sales.InMemoryRepository.Interface;
using Sales.Models;

namespace Sales.InMemoryRepository
{
    public class ProductInMemoryRepository : IProductRepository
    {
            private readonly List<Product> products;

            public ProductInMemoryRepository()
            {
                products = new List<Product>
                {
                new Product{ProductID = 1, ProductName = "Laptop", Specification = "14-inch Laptop with Intel i5", Price = 899.99M, StockQuantity = 10},
                new Product{ProductID = 2, ProductName = "Smartphone", Specification = "5.5-inch Smartphone with 64GB storage", Price = 299.99M, StockQuantity = 50}
                };
            }

            public void AddProduct(Product product)
            {
                products.Add(product);
            }

            public void DeleteProduct(int id)
            {
                Product productToDelete = GetProduct(id);
                if (productToDelete != null)
                {
                    products.Remove(productToDelete);
                }
            }

            public IEnumerable<Product> GetAll()
            {
                return products;
            }

            public Product GetProduct(int id)
            {
                return products.FirstOrDefault(product => product.ProductID == id);
            }

            public void UpdateProduct(Product product)
            {
                Product existingProduct = GetProduct(product.ProductID);
                if (existingProduct != null)
                {
                    existingProduct.ProductName = product.ProductName;
                    existingProduct.Specification = product.Specification;
                    existingProduct.Price = product.Price;
                    existingProduct.StockQuantity = product.StockQuantity;
                }
            }
       
    }
}
