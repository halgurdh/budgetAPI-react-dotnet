namespace BudgetApi.Data
{
    public class Income
    {
        public int IncomeId { get; set; }

        public string Name { get; set; }

        public DateTime Date { get; set; }

        public double Value { get; set; }

        public ICollection<Category> Categories { get; set; }
    }
}