using Sales.Data;
using Sales.Repository.Interface;
using Sales.Models;

namespace Sales.Repository
{
        public class ProductRepository : IProductRepository
        {
            //private readonly List<Product> products;

            //public ProductInMemoryRepository()
            //{
            //    products = new List<Product>
            //    {
            //    new Product{ProductID = 1, ProductName = "Laptop", Specification = "14-inch Laptop with Intel i5", Price = 899.99M, StockQuantity = 10},
            //    new Product{ProductID = 2, ProductName = "Smartphone", Specification = "5.5-inch Smartphone with 64GB storage", Price = 299.99M, StockQuantity = 50}
            //    };
            //}

            private readonly AppDbContext _appDbContext;

            public ProductRepository(AppDbContext appDbContext)
            {
                _appDbContext = appDbContext;
            }


            public void AddProduct(Product product)
            {
            _appDbContext.Product.Add(product);
            _appDbContext.SaveChanges();
        }

            public void DeleteProduct(int id)
            {
                Product product = GetProduct(id);
                if (product != null)
                {
                _appDbContext.Product.Remove(product);
                _appDbContext.SaveChanges();
            }
            }

            public IEnumerable<Product> GetAll()
            {
              return _appDbContext.Product.ToList();
            }

            public Product GetProduct(int id)
            {
            return _appDbContext.Product.FirstOrDefault(product => product.ProductID == id);
        }

            public void UpdateProduct(Product product)
            {

            if (product.PurchaseQuantity > product.StockQuantity)
                {
                throw new InvalidOperationException("Purchase quantity cannot be greater than stock quantity.");
                }
                Product existingProduct = _appDbContext.Product.Find(product.ProductID);
                if (existingProduct != null)
                {
                    existingProduct.ProductName = product.ProductName;
                    existingProduct.Price = product.Price;
                    existingProduct.StockQuantity = product.StockQuantity;
                    existingProduct.PurchaseQuantity = product.PurchaseQuantity;    
                }
            }

        }
}
