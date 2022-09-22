using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BudgetApi.Data
{
    internal sealed class CategoryDBContext : DbContext
    {
        public DbSet<Category> Category { get; set; }

        string connectionString = new ConfigurationBuilder().AddJsonFile("appsettings.Development.json").Build().GetSection("ConnectionStrings")["DefaultConnection"];

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder) => dbContextOptionsBuilder.UseSqlServer(connectionString);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
            .HasOne<Expenses>(s => s.Expenses)
            .WithMany(g => g.Categories)
            .HasForeignKey(s => s.ExpenseId);

            modelBuilder.Entity<Category>()
            .HasOne<Income>(s => s.Income)
            .WithMany(g => g.Categories)
            .HasForeignKey(s => s.IncomeId);

            Category[] CategoryToSeed = new Category[1];

            for (int i = 1; i <= CategoryToSeed.Length; i++)
            {
                CategoryToSeed[i-1] = new Category
                {
                        CategoryId= i,
                        Value="Other",
                };
            }

            modelBuilder.Entity<Category>().HasData(CategoryToSeed);
        }
    }
}