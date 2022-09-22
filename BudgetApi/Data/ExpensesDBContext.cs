using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace BudgetApi.Data
{
    internal sealed class ExpensesDBContext : DbContext
    {
        public DbSet<Expenses> Expenses { get; set; }

        string connectionString = new ConfigurationBuilder().AddJsonFile("appsettings.Development.json").Build().GetSection("ConnectionStrings")["DefaultConnection"];

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder) => dbContextOptionsBuilder.UseSqlServer(connectionString);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Expenses[] expensesToSeed = new Expenses[12];

            for (int i = 1; i <= expensesToSeed.Length; i++)
            {
                expensesToSeed[i-1] = new Expenses
                {
                    Id = i,
                    Date = DateTime.Now,
                    Value = 0,
                    Name = "testExpense"
                };
            }

            modelBuilder.Entity<Expenses>().HasData(expensesToSeed);
        }
    }
}