using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace BudgetApi.Data
{
    internal sealed class TotalDBContext : DbContext
    {
        public DbSet<Total> Total { get; set; }

        string connectionString = new ConfigurationBuilder().AddJsonFile("appsettings.Development.json").Build().GetSection("ConnectionStrings")["DefaultConnection"];

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder) => dbContextOptionsBuilder.UseSqlServer(connectionString);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Total[] expensesToSeed = new Total[12];

            for (int i = 1; i <= expensesToSeed.Length; i++)
            {
                expensesToSeed[i - 1] = new Total
                {
                    TotalId = i,
                    Date = DateTime.Now,
                    Value = 0,
                    Name = "testTotal"
                };
            }

            modelBuilder.Entity<Total>().HasData(expensesToSeed);
        }
    }
}