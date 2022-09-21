namespace BudgetApi.Data
{
    public class Expenses
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime Date { get; set; }

        public double Value { get; set; }
    }
}