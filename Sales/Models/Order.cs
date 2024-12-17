namespace Sales.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderStatus { get; set; }
        public double TotalAmount { get; set; }
    }
}
