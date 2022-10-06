namespace BudgetApi.Data
{
    public class Income
    {
        public Guid IncomeID { get; set; }

        public string Name { get; set; }

        public DateTime Date { get; set; }

        public double Value { get; set; }

        public Guid CategoryID { get; set; }
    }
}