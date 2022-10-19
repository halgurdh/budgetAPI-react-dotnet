using Microsoft.EntityFrameworkCore;

namespace BudgetApi.Data
{
    internal static class TotalRepository
    {
        internal async static Task<List<Total>> GetTotalAsync()
        {
            using (var db = new BudgetDBContext())
            {
                var incomeDb = await db.Income.ToListAsync();
                var expensesDb = await db.Expenses.ToListAsync();

                double totalExpenses = 0;
                double totalIncome = 0;

                foreach (var expense in expensesDb)
                {
                    totalExpenses += expense.Value;
                }

                foreach (var income in incomeDb)
                {
                    totalIncome += income.Value;
                }

                double totalAmount = totalIncome - totalExpenses;

                var totalToUpdate = new Total()
                {
                    Value = totalAmount,
                    Date = DateTime.Now,
                    Name = ""
                };

                db.Total.Add(totalToUpdate);

                return await db.Total.ToListAsync();
            }
        }

        internal async static Task<Total> GetTotalByCategory(Category category)
        {
            using (var db = new BudgetDBContext())
            {
                return await db.Total.FirstOrDefaultAsync(budget => category.CategoryID == budget.CategoryID);
            }
        }

        internal async static Task<bool> GetAllTotal(Total totalToCreate)
        {
            using (var db = new BudgetDBContext())
            {
                try
                {
                    db.Total.AddAsync(totalToCreate);

                    return await db.SaveChangesAsync() >= 1;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        internal async static Task<bool> CreateTotalAsync(Total totalToCreate)
        {
            using (var db = new BudgetDBContext())
            {
                try
                {
                    db.Total.AddAsync(totalToCreate);

                    return await db.SaveChangesAsync() >= 1;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        internal async static Task<bool> UpdateTotalAsync(Total totalToUpdate)
        {
            using (var db = new BudgetDBContext())
            {
                try
                {
                    db.Total.Update(totalToUpdate);

                    return await db.SaveChangesAsync() >= 1;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
    }
}
