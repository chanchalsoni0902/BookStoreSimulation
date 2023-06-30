using System.Net;

namespace BookStoreSimulation
{
    public class BookOperations
    {
        public List<Book> Books = new List<Book>();
        public FileHandler fileHandler = new FileHandler();

        public BookOperations()
        {
            GetDataFromFile();
        }
        public void GetDataFromFile()
        {
            Books = fileHandler.GetBooks();
        }

        public void SaveDataToJsonFile()
        {
            fileHandler.SaveBooks(Books);
        }

        public void AddBook(Book book)
        {
            book.Id = GenerateId();
            book.CreatedOn = DateTime.Now.GetDate();
            Books.Add(book);
            SaveDataToJsonFile();
        }

        public void DisplayAllBook()
        {
            GetDataFromFile();
            Console.WriteLine("\nId -> Title -> Author -> Quantity -> Price -> LastUpdate");
            Books.ForEach(book =>
            {
                Console.WriteLine($"{book.Id} -> {book.Title} -> {book.Author} -> {book.Quantity} -> {book.Price} -> {book.UpdatedOn}");
            });
        }

        public void DisplayById(int bookId)
        {
            GetDataFromFile();
            Book bk = GetBook(bookId);
            if (bk == null)
            {
                Console.WriteLine("Book not found");
            }
            else
            {
                Console.WriteLine("\nId -> Author -> Title -> Quantity -> Price -> LastUpdate");
                Console.WriteLine($"{bk.Id} -> {bk.Author} -> {bk.Title} -> {bk.Quantity} -> {bk.UpdatedOn}");
            }
        }

        public void UpdateBook(Book book)
        {
            Book bk = GetBook(book.Id);
            if (bk == null)
            {
                Console.WriteLine("Book not found");
            }
            else
            {
                bk.Author = book.Author;
                bk.Title = book.Title;
                bk.Price = book.Price;
                bk.Quantity = book.Quantity;
                bk.Version = book.Version;
                bk.UpdatedOn = DateTime.Now.GetDate();
            }
            SaveDataToJsonFile();
        }

        public void RemoveBook(int bookId)
        {
            Book bk = GetBook(bookId);
            if (bk == null)
            {
                Console.WriteLine("Book not found");
            }
            else
            {
                Books.Remove(bk);
            }
            SaveDataToJsonFile();        }

        public void UpdateQuantity(int bookId, int quantity)
        {
            Book book = GetBook(bookId);
            if (book == null)
            {
                Console.WriteLine("Book not found");
            }
            else
            {
                book.Quantity = book.Quantity + quantity;
            }
            SaveDataToJsonFile();
        }

        public Book GetBook(int id)
        {
            try
            {
                return Books.SingleOrDefault(item => item.Id == id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public Book ValidateQuantityAndGetBook(int bookId, int quantity)
        {
            Book book = GetBook(bookId);
            if(book == null)
            {
                Console.WriteLine("Invalid Selection");
                return null;
            }
            else if (book.Quantity < quantity)
            {
                Console.WriteLine("Selected quantity is more than avail quantity.");
                return null;
            }
            else
            {
                book.Quantity = book.Quantity - quantity;

                // book customer want to purchase
                Book myBook = new Book();
                myBook.Id = bookId;
                myBook.Quantity = quantity;
                myBook.Author = book.Author;
                myBook.Price = book.Price;
                myBook.Version = book.Version;
                myBook.CreatedOn = book.CreatedOn;
                myBook.UpdatedOn = book.UpdatedOn;
                myBook.Title = book.Title;
                SaveDataToJsonFile();
                return myBook;
            }
        }
        
        public int GenerateId()
        {
            Book book = Books.LastOrDefault();
            if(book == null)
            {
                return 1;
            }
            else
            {
                return book.Id + 1;
            }
        }
    }
}
