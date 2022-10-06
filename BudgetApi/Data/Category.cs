namespace BudgetApi.Data
{
    public class Category
    {
        public Guid CategoryID { get; set; }

        public string Name { get; set; }

        public ICollection<Expenses> Expenses { get; set; }

        public ICollection<Income> Income { get; set; }

        public ICollection<Total> Total { get; set; }

    }
}