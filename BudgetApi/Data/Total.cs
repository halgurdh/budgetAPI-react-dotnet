namespace BudgetApi.Data
{
    public class Total
    {
        public int TotalId { get; set; }

        public string Name { get; set; }

        public DateTime Date { get; set; }

        public double Value { get; set; }

        public int ExpensesId { get; set; }

        public Expenses Expenses { get; set; }

        public int IncomeId { get; set; }

        public Income Income { get; set; }
    }
}