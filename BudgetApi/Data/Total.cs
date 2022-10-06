namespace BudgetApi.Data
{
    public class Total
    {
        public Guid TotalID { get; set; }

        public string Name { get; set; }

        public DateTime Date { get; set; }

        public double Value { get; set; }

        public Guid CategoryID { get; set; }
    }
}