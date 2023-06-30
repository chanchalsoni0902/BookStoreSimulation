using static System.Reflection.Metadata.BlobBuilder;

namespace BookStoreSimulation
{
    public class CustomerOperations
    {
        public List<Customer> Customers = new List<Customer>();
        public FileHandler fileHandler = new FileHandler();

        public CustomerOperations()
        {
            GetDataFromFile();
        }

        public void GetDataFromFile()
        {
            Customers = fileHandler.GetCustomers();
        }

        public void SaveDataToJsonFile()
        {
            fileHandler.SaveCustomers(Customers);
        }

        public void AddCustomer(Customer customer)
        {
            customer.Id = GenerateId();
            Customers.Add(customer);
            SaveDataToJsonFile();
        }

        public void DisplayAllCustomer()
        {
            GetDataFromFile();
            Console.WriteLine("\nId -> Name -> Contact -> Email -> Address");
            Customers.ForEach(customer =>
            {
                Console.WriteLine($"{customer.Id} -> {customer.Name} -> {customer.Contact} -> {customer.Email} -> {customer.Email}");
            });
        }

        public void DisplayCustomerById(int id) 
        {
            GetDataFromFile();
            Customer customer = GetCustomer(id);
            if (customer == null) 
            {
                Console.WriteLine("Customer not found");
            }
            else
            {
                Console.WriteLine("\nId -> Name -> Contact -> Email -> Address");
                Console.WriteLine($"{customer.Id} -> {customer.Name} -> {customer.Contact} -> {customer.Email} -> {customer.Email}");
            }
        }

        public Customer GetCustomer(int id)
        {
            try
            {
                return Customers.SingleOrDefault(customer => customer.Id == id);
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public Customer GetCustomerById(int id)
        {
            GetDataFromFile();
            Customer customer = GetCustomer(id);
            if (customer == null)
            {
                Console.WriteLine("Customer not found");
                return null;
            }
            else
            {
                return customer;
            }
        }

        public void UpdateCustomer(Customer customer)
        {
            Customer cs = GetCustomer(customer.Id);
            if (cs == null)
            {
                Console.WriteLine("Customer not found");
            }
            else
            {
                cs.Name = customer.Name;
                cs.Address = customer.Address;
                cs.Contact = customer.Contact;
            }
            SaveDataToJsonFile();
        }

        public void RemoveCustomer(int customerId)
        {
            Customer cs = GetCustomer(customerId);
            if (cs == null)
            {
                Console.WriteLine("Customer not found");
            }
            else
            {
                Customers.Remove(cs);
            }
            SaveDataToJsonFile();
        }

        public int GenerateId()
        {
            Customer data = Customers.LastOrDefault();
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
