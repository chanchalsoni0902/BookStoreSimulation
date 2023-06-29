namespace BookStoreSimulation
{
    public class Order
    {
        public int Id;
        public List<Book> Books = new List<Book>();
        public int CustomerId;
        public int TotalQuantity;
        public float TotalPrice;
        public DateTime DateOfPurchase;
    }
}
