using Newtonsoft.Json;

namespace BookStoreSimulation
{
    public class FileHandler
    {
        const string booksFilePath = "C:\\Users\\bootcamp\\Desktop\\Chanchal\\Task\\BookStoreSimulation\\Files\\books.json";
        const string ordersFilePath = "C:\\Users\\bootcamp\\Desktop\\Chanchal\\Task\\BookStoreSimulation\\Files\\orders.json";
        const string customersPath = "C:\\Users\\bootcamp\\Desktop\\Chanchal\\Task\\BookStoreSimulation\\Files\\customers.json";
       
        public void SaveBooks(List<Book> data)
        {
            StreamWriter writer = new StreamWriter(booksFilePath);
            string json = JsonConvert.SerializeObject(data);
            writer.WriteLine(json);
            writer.Close();
        }

        public List<Book> GetBooks()
        {
            StreamReader reader = new StreamReader(booksFilePath);
            string data = reader.ReadToEnd();
            if (string.IsNullOrEmpty(data))
            {
                return new List<Book>();
            }
            List<Book> result = JsonConvert.DeserializeObject<List<Book>>(data);            
            reader.Close();
            return result;
        }

        public void SaveOrders(List<Order> data)
        {
            StreamWriter writer = new StreamWriter(ordersFilePath);
            string json = JsonConvert.SerializeObject(data);
            writer.WriteLine(json);
            writer.Close();
        }

        public List<Order> GetOrders()
        {
            StreamReader reader = new StreamReader(ordersFilePath);
            string data = reader.ReadToEnd();
            if (string.IsNullOrEmpty(data))
            {
                return new List<Order>();
            }
            List<Order> result = JsonConvert.DeserializeObject<List<Order>>(data);            
            reader.Close();
            return result;

        }

        public void SaveCustomers(List<Customer> data)
        {
            StreamWriter writer = new StreamWriter(customersPath);
            string json = JsonConvert.SerializeObject(data);
            writer.WriteLine(json);
            writer.Close();
        }

        public List<Customer> GetCustomers()
        {
            StreamReader reader = new StreamReader(customersPath);
            string data = reader.ReadToEnd();
            if (string.IsNullOrEmpty(data))
            {
                return new List<Customer>();
            }
            List<Customer> result = JsonConvert.DeserializeObject<List<Customer>>(data);            
            reader.Close();
            return result;
        }
    }

}
