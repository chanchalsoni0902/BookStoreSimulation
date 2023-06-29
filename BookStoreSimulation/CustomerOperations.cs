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
            customer.Id = Customers.Count() + 1;
            Customers.Add(customer);
            SaveDataToJsonFile();
        }

        public void DisplayAllCustomer()
        {
            GetDataFromFile();
            Customers.ForEach(customer =>
            {
                Console.WriteLine($"{customer.Id} -> {customer.Name} -> {customer.Address} -> {customer.Contact}");
            });
        }

        public void DisplayCustomerById(int id) 
        {
            GetDataFromFile();
            Customer customer = Customers.SingleOrDefault(cs => cs.Id == id);
            if (customer == null) 
            {
                Console.WriteLine("Customer not found");
            }
            else
            {
                Console.WriteLine($"{customer.Id} -> {customer.Name} -> {customer.Address} -> {customer.Contact}");
            }
        }

        public void UpdateCustomer(Customer customer)
        {
            Customer cs = Customers.SingleOrDefault(customer => customer.Id == customer.Id);
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
            Customer cs = Customers.SingleOrDefault(customer => customer.Id == customerId);
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

    }
}
