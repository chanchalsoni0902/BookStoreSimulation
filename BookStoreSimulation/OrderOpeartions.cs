namespace BookStoreSimulation
{
    public class OrderOpeartions
    {
        public List<Order> Orders = new List<Order>();
        public FileHandler fileHandler = new FileHandler();

        public OrderOpeartions()
        {
            GetDataFromFile();
        }

        public void GetDataFromFile()
        {
            Orders = fileHandler.GetOrders();
        }

        public void SaveDataToJsonFile()
        {
            fileHandler.SaveOrders(Orders);
        }

        public void AddOrder(Order order)
        {
            order.Id = Orders.Count() + 1;
            Orders.Add(order);
            SaveDataToJsonFile();
        }

        public void DisplayAllOrders()
        {
            GetDataFromFile();
            Orders.ForEach(order =>
            {
                Console.WriteLine($"{order.Id} -> {order.DateOfPurchase} -> {order.CustomerId} -> {order.TotalPrice} -> {order.TotalQuantity}");
            });
        }

        public void DisplayOrderById(int id)
        {
            GetDataFromFile();
            Order order = Orders.SingleOrDefault(ord => ord.Id == id);
            if (order == null)
            {
                Console.WriteLine("Order not found");
            }
            else
            {
                Console.WriteLine($"{order.Id} -> {order.DateOfPurchase} -> {order.CustomerId} -> {order.TotalPrice} -> {order.TotalQuantity}");
            }
        }

        public void UpdateCustomer(int customerId, Customer customer)
        {
            Order ord = Orders.SingleOrDefault(customer => customer.Id == customerId);
            if (ord == null)
            {
                Console.WriteLine("Order not found");
            }
            else
            {
                ord.DateOfPurchase = ord.DateOfPurchase;
                ord.CustomerId = ord.CustomerId;
            }
            SaveDataToJsonFile();
        }

        public void RemoveOrder(int customerId)
        {
            Order order = Orders.SingleOrDefault(ord => ord.Id == customerId);
            if (order == null)
            {
                Console.WriteLine("Order not found");
            }
            else
            {
                Orders.Remove(order);
            }
            SaveDataToJsonFile();
        }

        public void SellBooks(int customerId, List<Book> books)
        {
            Order order = new Order();
            order.Id = Orders.Count() + 1;
            order.CustomerId = customerId;

            int totalQuantity = 0;
            float totalPrice = 0;

            books.ForEach(book =>
            {
                totalQuantity = totalQuantity +  book.Quantity;
                totalPrice = (totalPrice + book.Price) * book.Quantity;
            });

            order.TotalQuantity = totalQuantity;
            order.TotalPrice = totalPrice;
            Console.WriteLine($"You bought {totalQuantity} for Rs. {totalPrice}");
            Orders.Add(order);
            SaveDataToJsonFile();
        }
    }
}
