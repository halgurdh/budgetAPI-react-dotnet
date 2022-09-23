namespace BudgetApi.Data
{
    public class Total
    {
        public int TotalId { get; set; }

        public string Name { get; set; }

        public DateTime Date { get; set; }

        public double Value { get; set; }

        public ICollection<Category> Categories { get; set; }
    }
}