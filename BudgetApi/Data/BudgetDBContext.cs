using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BudgetApi.Data
{
    internal sealed class BudgetDBContext : DbContext
    {
        public DbSet<Category> Category { get; set; }
        public DbSet<Expenses> Expenses { get; set; }
        public DbSet<Income> Income { get; set; }
        public DbSet<Total> Total { get; set; }

        string connectionString = new ConfigurationBuilder().AddJsonFile("appsettings.Development.json").Build().GetSection("ConnectionStrings")["DefaultConnection"];

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder) => dbContextOptionsBuilder.UseSqlServer(connectionString);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var expenseID = Guid.NewGuid();
            var incomeID = Guid.NewGuid();
            var totalID = Guid.NewGuid();

            var expenseValue = 670.00;
            var incomeValue = 2950.00;
            var totalValue = incomeValue-expenseValue;

            Expenses expensesToSeed = new Expenses{
                ExpensesID = expenseID,
                Categories = new List<Category>(),
                Date = DateTime.Now,
                Name = "Appartment",
                Value = expenseValue
            };

            Income incomeToSeed = new Income
            {
                IncomeID = incomeID,
                Categories = new List<Category>(),
                Date = DateTime.Now,
                Name = "Money B.V",
                Value = incomeValue
            };

            Total totalToSeed = new Total
            {
                TotalID = totalID,
                Categories = new List<Category>(),
                Date = DateTime.Now,
                Name = "Money B.V",
                Value = totalValue
            };

            string[] catagoryList = { "Rent", "Salary", "Other"};

            List<Category> catagoriesToSeed = new List<Category>();

            for (int i = 0; i < catagoryList.Count(); i++)
            {
                catagoriesToSeed.Add(new Category
                {
                    CategoryID = Guid.NewGuid(),
                    Name = catagoryList[i],
                    ExpensesID = expenseID,
                    IncomeID = incomeID,
                    TotalID = totalID
                });
            }

            modelBuilder.Entity<Expenses>().HasData(expensesToSeed);
            modelBuilder.Entity<Income>().HasData(incomeToSeed);
            modelBuilder.Entity<Total>().HasData(totalToSeed);
            modelBuilder.Entity<Category>().HasData(catagoriesToSeed);
        }
    }
}