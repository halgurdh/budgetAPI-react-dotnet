namespace BudgetApi.Data
{
    public class Category
    {
        public int CategoryId { get; set; }

        public string Value { get; set; }

        public int ExpenseId { get; set; }

        public int IncomeId { get; set; }

        public int TotalId { get; set; }

        public Expenses Expenses { get; set; }

        public Income Income { get; set; }

        public Total Total { get; set; }
    }
}