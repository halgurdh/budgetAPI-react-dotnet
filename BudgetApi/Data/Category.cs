namespace BudgetApi.Data
{
    public class Category
    {
        public Guid CategoryID { get; set; }

        public string Name { get; set; }

        public Guid ExpensesID { get; set; }

        public Guid IncomeID { get; set; }

        public Guid TotalID { get; set; }
    }
}