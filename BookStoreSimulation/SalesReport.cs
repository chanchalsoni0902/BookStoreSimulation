namespace BookStoreSimulation
{
    public class SalesReport
    {
        FileHandler fileHandler = new FileHandler();

        public void GenerateMonthlyReport()
        {
            List<Order> orders = fileHandler.GetOrders();
            List<MonthlyReport> report = orders.GroupBy(prop => prop.DateOfPurchase.Month)
                .Select(order => new MonthlyReport()
                {
                    Month = GetMonthName(order.Key),
                    TotalQutantitySold = order.Sum(s => s.TotalQuantity),
                    TotalRevenue = order.Sum(s => s.TotalPrice)
                }).ToList();

            report.ForEach(reportItem =>
            {
                Console.WriteLine($"Month: {reportItem.Month}, Total Quantity Sold: {reportItem.TotalQutantitySold}, Total Revenue: ${reportItem.TotalRevenue}");
            });
        }

        public void DisplayPercentRevenueForMonth(int month)
        {
            int prevMonth = month - 1;  

            List<Order> orders = fileHandler.GetOrders();
            List<MonthlyReport> monthlyReports = orders.GroupBy(prop => prop.DateOfPurchase.Month)
                .Select(order => new MonthlyReport()
                {
                    MonthNumber = order.Key,
                    Month = GetMonthName(order.Key),
                    TotalQutantitySold = order.Sum(s => s.TotalQuantity),
                    TotalRevenue = order.Sum(s => s.TotalPrice)
                }).ToList();

            MonthlyReport prev = monthlyReports.SingleOrDefault(m => m.MonthNumber == prevMonth);
            if(prev == null)
            {
                Console.WriteLine("Sorry could not calculate revenue % as historic data is not sufficientl");
                return;
            }
            MonthlyReport current = monthlyReports.SingleOrDefault(m => m.MonthNumber == month);
            if(current == null)
            {
                Console.WriteLine("Sorry could not calculate revenue % as data is not sufficient");
                return;
            }

            float prevRevenue = prev.TotalRevenue;
            float currentRevenue = current.TotalRevenue;

            float diff = (prevRevenue - currentRevenue);
            float percent = (diff / prevRevenue)*100;

            Console.WriteLine($"Revenue percent for this month is {percent} %");
        }

        private string GetMonthName(int month)
        {
            DateTime dt = new DateTime(2023, month, 1);

            return dt.ToString("MMMM");
        }
    }
}

public class MonthlyReport
{
    public int MonthNumber;
    public string Month;
    public float TotalRevenue;
    public int TotalQutantitySold;
}