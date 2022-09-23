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
            modelBuilder.Entity<Category>()
            .HasOne<Expenses>(s => s.Expenses)
            .WithMany(g => g.Categories)
            .HasForeignKey(s => s.ExpenseId);

            modelBuilder.Entity<Category>()
            .HasOne<Income>(s => s.Income)
            .WithMany(g => g.Categories)
            .HasForeignKey(s => s.IncomeId);

            modelBuilder.Entity<Category>()
            .HasOne<Total>(s => s.Total)
            .WithMany(g => g.Categories)
            .HasForeignKey(s => s.IncomeId);
        }
    }
}