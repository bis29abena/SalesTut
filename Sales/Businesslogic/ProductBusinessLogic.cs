
using Sales.Businesslogic.Interface;
using Sales.Models;
using Sales.Repository.Interface;

namespace Sales.Businesslogic
{
    public class ProductBusinessLogic : IProductBusinessLogic
    {
      private readonly IProductRepository _productRepository;

      public ProductBusinessLogic (IProductRepository productRepository)

      {
            _productRepository = productRepository;
      }

        public Product AddProducts(Product product)
        {
            if (product.PurchaseQuantity > product.StockQuantity)
            {
                throw new InvalidOperationException("Purchase quantity cannot be greater than stock quantity.");
            }

            string normalizedProductName = product.ProductName.Trim().ToLower();

            var existingProduct = _productRepository.GetAll()
                .FirstOrDefault(p => p.ProductName.Trim().ToLower() == normalizedProductName);

            if (existingProduct != null)
            {
                throw new InvalidOperationException("A product with the same name already exists.");
            }

            var productRepository = _productRepository.GetAll();
            if (productRepository.Any())
            {
                var lastProduct = productRepository.OrderByDescending(p => p.ProductID).FirstOrDefault();
                int lastProductID = lastProduct.ProductID + 1;
                product.ProductID = lastProductID;

            }


            _productRepository.AddProduct(product);
            return product;
        }      
       
    } 
}
