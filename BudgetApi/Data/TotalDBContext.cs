using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace BudgetApi.Data
{
    internal sealed class TotalDBContext : DbContext
    {
        public DbSet<Total> Total { get; set; }

        string connectionString = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("ConnectionStrings")["DefaultConnection"];

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder) => dbContextOptionsBuilder.UseSqlServer(connectionString);

        private double calulateTotal(int index)
        {
            double incomes = IncomeRepository.GetMonthlyIncomeById(index).Result.Value;
            double expenses = ExpenseRepository.GetMonthlyExpenseById(index).Result.Value;

            return incomes - expenses;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Total[] expensesToSeed = new Total[12];

            for (int i = 1; i <= expensesToSeed.Length; i++)
            {
                expensesToSeed[i - 1] = new Total
                {
                    Id = i,
                    Date = DateTime.Now,
                    Value = calulateTotal(i),
                    Name = "testTotal"
                };
            }

            modelBuilder.Entity<Total>().HasData(expensesToSeed);
        }
    }
}