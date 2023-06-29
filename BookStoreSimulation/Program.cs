using BookStoreSimulation;

public class Program
{
    static BookOperations bookOperations = new BookOperations();
    static OrderOpeartions orderOperations = new OrderOpeartions();
    static CustomerOperations customerOperations = new CustomerOperations();
    public static void Main(string[] args)
    {

        while (true)
        {
            try
            {
                DisplayMenu();
                int option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 0:
                        Environment.Exit(0);
                        break;

                        // Books
                    case 1:
                        // 1. Add new book.
                        GetDataFromUserAndAddBook();
                        break;
                    case 2:
                        // Display all book
                        bookOperations.DisplayAllBook();
                        break;
                    case 3:
                        // Display book by id
                        Console.WriteLine("Enter book id: ");
                        int bookId = int.Parse(Console.ReadLine());
                        bookOperations.DisplayById(bookId);
                        break;
                    case 4:
                        // Update book
                        Console.WriteLine("Enter book id: ");
                        int id = int.Parse(Console.ReadLine());

                        Book book = new Book();
                        book.Id = id;
                        Console.WriteLine("Enter title: ");
                        book.Title = Console.ReadLine();

                        Console.WriteLine("Enter Author: ");
                        book.Author = Console.ReadLine();

                        Console.WriteLine("Enter unit price: ");
                        book.Price = float.Parse(Console.ReadLine());

                        Console.WriteLine("Enter quantity: ");
                        book.Quantity = int.Parse(Console.ReadLine());

                        bookOperations.UpdateBook(book);
                        break;
                    case 5:
                        // Update book quantity
                        Console.WriteLine("Enter book id: ");
                        int bkId = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter Quantity : ");
                        int quantity = int.Parse(Console.ReadLine());
                        bookOperations.UpdateQuantity(bkId, quantity);
                        break;

                    case 6:
                        // remove book
                        Console.WriteLine("Enter book id: ");
                        int bokId = int.Parse(Console.ReadLine());
                        bookOperations.RemoveBook(bokId);

                        break;

                        // Orders
                    case 11:
                        // Sell book
                        SellBooks();
                        break;
                    case 12:
                        //  Display all orders.
                        orderOperations.DisplayAllOrders();
                        break;
                    case 13:
                        // Find order
                        Console.WriteLine("Enter order id: ");
                        int orderId = int.Parse(Console.ReadLine());
                        orderOperations.DisplayOrderById(orderId);
                        break;

                        // Customers
                    case 21:
                        // Add customer
                        Customer customer = new Customer();
                        Console.WriteLine("Enter name: ");
                        customer.Name = Console.ReadLine();
                        Console.WriteLine("Enter contact number: ");
                        customer.Contact = Console.ReadLine();
                        Console.WriteLine("Enter address: ");
                        customer.Address = Console.ReadLine();

                        customerOperations.AddCustomer(customer);
                        break;
                    case 22:
                        // Update customer
                        Console.WriteLine("Enter id of cutomer you want to update: ");
                        int custId = int.Parse(Console.ReadLine());

                        customer = new Customer();
                        Console.WriteLine("Enter name: ");
                        customer.Name = Console.ReadLine();
                        Console.WriteLine("Enter contact number: ");
                        customer.Contact = Console.ReadLine();
                        Console.WriteLine("Enter address: ");
                        customer.Address = Console.ReadLine();
                        customerOperations.UpdateCustomer(customer);
                        break;
                    case 23:
                        // Display all customer
                        customerOperations.DisplayAllCustomer();
                        break;
                    case 24:
                        // Display customer by id
                        Console.WriteLine("Enter customer id: ");
                        int customerId = int.Parse(Console.ReadLine());
                        customerOperations.DisplayCustomerById(customerId);
                        break;
                    case 25:
                        // Delete customer
                        Console.WriteLine("Enter customer id: ");
                        int cId = int.Parse(Console.ReadLine());
                        customerOperations.RemoveCustomer(cId);
                        break;

                    default:
                        Console.WriteLine("Invalid Selection");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }

    public static void GetDataFromUserAndAddBook()
    {
        Book book = new Book();

        Console.WriteLine("Enter title: ");
        book.Title = Console.ReadLine();

        Console.WriteLine("Enter Author: ");
        book.Author = Console.ReadLine();

        Console.WriteLine("Enter unit price: ");
        book.Price = float.Parse(Console.ReadLine());

        Console.WriteLine("Enter quantity: ");
        book.Quantity = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter version: ");
        book.Version = int.Parse(Console.ReadLine());

        book.CreatedOn = DateTime.Now;
        book.UpdatedOn = DateTime.Now;

        bookOperations.AddBook(book);
    }

    public static void DisplayMenu()
    {
        Console.WriteLine("\nSelect from the following option: ");

        Console.WriteLine("1. Add new book.");
        Console.WriteLine("2. Display all books.");
        Console.WriteLine("3. Find book.");
        Console.WriteLine("4. Update book.");
        Console.WriteLine("5. Update quantity.");
        Console.WriteLine("6. Remove Book.");

        Console.WriteLine("11. Sell book.");
        Console.WriteLine("12. Display all orders.");
        Console.WriteLine("13. Find order.");

        Console.WriteLine("21. Add new customer."); 
        Console.WriteLine("22. Update customer.");
        Console.WriteLine("23. Display all customers.");
        Console.WriteLine("24. Find customer.");

        Console.WriteLine("0. Exit\n");
    }

    public static void SellBooks()
    {
        List<Book> myBooks = new List<Book>();
       while (true)
        {
            
            bookOperations.DisplayAllBook();
            Console.WriteLine("Enter 0 for generate receipt");
            Console.WriteLine("\nSelect book: ");

            int bookId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter CustomerId: ");
            int customerId = int.Parse(Console.ReadLine());

            if (bookId == 0)
            {
                orderOperations.SellBooks(customerId, myBooks);
                return;
            }

            Console.WriteLine("\nEnter quatity: ");
            int qty = int.Parse(Console.ReadLine());        

            Book book = bookOperations.ValidateAndGetBook(bookId, qty);
            myBooks.Add(book);

            
        }
    }
}
