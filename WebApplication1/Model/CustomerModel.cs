namespace WebApplication1.Model
{
    // Customer Model
    public class Customer
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string EmailContact { get; set; }
        public string PhoneContact { get; set; }
        public string Address { get; set; }
    }

    // Order Model
    public class Order
    {
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public string ItemDescription { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }
        public string OrderDescription { get; set; }
    }
}
