namespace BudgetApi.Data
{
    public class Expenses
    {
        public Guid ExpensesID { get; set; }

        public string Name { get; set; }

        public DateTime Date { get; set; }

        public double Value { get; set; }

        public Guid CategoryID { get; set; }

    }
}