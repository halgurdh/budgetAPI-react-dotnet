using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace BudgetApi.Data
{
    internal sealed class IncomeDBContext : DbContext
    {
        public DbSet<Income> Income { get; set; }

        string connectionString = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("ConnectionStrings")["DefaultConnection"];

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder) => dbContextOptionsBuilder.UseSqlServer(connectionString);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Income[] expensesToSeed = new Income[12];

            for (int i = 1; i <= expensesToSeed.Length; i++)
            {
                expensesToSeed[i-1] = new Income
                {
                    Id = i,
                    Date = DateTime.Now,
                    Value = 0,
                    Name = "testIncome"
                };
            }

            modelBuilder.Entity<Income>().HasData(expensesToSeed);
        }
    }
}