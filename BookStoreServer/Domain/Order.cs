namespace BookStoreServer
{
    public class OrderItem 
    {
        public string isbn { get; set; }
        public string name { get; set; }
        public int amount { get; set; }
        public int price { get; set; }
    }
    public class Order
    {
        public string buyerName { get; set; }
        public double price { get; set; }

        public OrderItem[] items { get; set; }
    }
}