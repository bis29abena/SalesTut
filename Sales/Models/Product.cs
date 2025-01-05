namespace Sales.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public int CategoryID { get; set; } 
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public int PurchaseQuantity { get; set; }   

    }
}
