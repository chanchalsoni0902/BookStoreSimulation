namespace BookStoreSimulation
{
    public class SalesReport
    {
        FileHandler fileHandler = new FileHandler();
        List<Book> soldBooks = new List<Book>();

        public void GenerateReport()
        {
            int totalSales = GetTotalSales();
            ExtractBook();

            List<BookResult> books = soldBooks
                .GroupBy(item => item.Id)
                .SelectMany(data => data.Select(book => new BookResult()
                {
                    Id = book.Id,
                    Quantity = data.Count(),
                    Title = book.Title,
                    Author = book.Author
                })).ToList();

            // Diaplay Report
            BookResult topSellingBook = books.OrderByDescending(prop => prop.Quantity).First();
            Console.WriteLine($"TotalSales: {totalSales}");
            Console.WriteLine($"Top Selling Book: \n Id: {topSellingBook.Id} -> Title: {topSellingBook.Title}");
        }

        private int GetTotalSales()
        {
            int total = 0;
            List<Order> orders = fileHandler.GetOrders();
            orders.ForEach(item =>
            {
                total += item.TotalQuantity;
            });
            return total;
        }

        private void ExtractBook()
        {
            List<Order> orders = fileHandler.GetOrders();
            if (orders == null || orders.Count() < 1)
            {
                Console.WriteLine("No orders found!!");
            }
            else
            {
                orders.ForEach(item =>
                {
                    soldBooks.AddRange(item.Books);
                });
            }
        }
    }
}

public class BookResult
{
    public int Id;
    public int Quantity;
    public string Title;
    public string Author;
}
