namespace BookStoreSimulation
{
    public class OrderOpeartions
    {
        public List<Order> Orders = new List<Order>();
        public CustomerOperations customerOperations = new CustomerOperations();
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
            order.Id = GenerateId();
            Orders.Add(order);
            SaveDataToJsonFile();
        }

        public void DisplayAllOrders()
        {
            GetDataFromFile();
            Console.WriteLine("\nId -> CustomerId -> TotalQuantity -> TotalPric -> DateOfPurchase");

            Orders.ForEach(order =>
            {
                Console.WriteLine($"{order.Id} -> {order.CustomerId} -> {order.TotalQuantity} -> {order.TotalPrice}  ->  -> {order.DateOfPurchase}");
            });
        }

        public void DisplayOrderById(int id)
        {
            GetDataFromFile();
            Order order = GetOrder(id);
            if (order == null)
            {
                Console.WriteLine("Order not found");
            }
            else
            {
                Console.WriteLine("\nId -> CustomerId -> TotalQuantity -> TotalPric -> DateOfPurchase");
                Console.WriteLine($"{order.Id} -> {order.CustomerId} -> {order.TotalQuantity} -> {order.TotalPrice}  ->  -> {order.DateOfPurchase}");
            }
        }

        public void UpdateOrder(Order order)
        {
            Order ord = GetOrder(order.Id);
            if (ord == null)
            {
                Console.WriteLine("Order not found");
            }
            else
            {
                ord.DateOfPurchase = order.DateOfPurchase;
                ord.CustomerId = order.CustomerId;
            }
            SaveDataToJsonFile();
        }

        public void RemoveOrder(int orderId)
        {
            Order order = GetOrder(orderId);
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
            order.DateOfPurchase = DateTime.Now.GetDate();
            order.Id = GenerateId();
            order.Books = books;
            order.CustomerId = customerId;
            Customer customer = customerOperations.GetCustomerById(customerId);

            int totalQuantity = 0;
            float totalPrice = 0;

            books.ForEach(book =>
            {
                totalQuantity = totalQuantity +  book.Quantity;
                totalPrice = (totalPrice + book.Price) * book.Quantity;
            });

            order.TotalQuantity = totalQuantity;
            order.TotalPrice = totalPrice;
            Orders.Add(order);
            SaveDataToJsonFile();

            Console.WriteLine($"\nName: {customer.Name} \nContact: {customer.Contact}");
            Console.WriteLine($"Total Items:  {totalQuantity}");
            Console.WriteLine($"Total Price Rs. {totalPrice}");
            Console.WriteLine($"Date of Purchase: {order.DateOfPurchase}");            
        }

        public Order GetOrder( int orderId )
        {
            return Orders.SingleOrDefault(item => item.Id == orderId);
        }

        public int GenerateId()
        {
            Order data = Orders.LastOrDefault();
            if (data == null)
            {
                return 1;
            }
            else
            {
                return data.Id + 1;
            }
        }
    }
}
