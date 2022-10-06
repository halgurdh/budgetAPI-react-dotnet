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
            string[] catagoryList = { "Rent", "Salary", "Other"};

            List<Category> catagoriesToSeed = new List<Category>();

            for (int i = 0; i < catagoryList.Count(); i++)
            {
                catagoriesToSeed.Add(new Category
                {
                    CategoryID = Guid.NewGuid(),
                    Name = catagoryList[i]
                });
            }

            modelBuilder.Entity<Category>().HasData(catagoriesToSeed);
        }
    }
}