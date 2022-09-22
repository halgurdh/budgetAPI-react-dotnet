using Microsoft.EntityFrameworkCore;

namespace BudgetApi.Data
{
    internal static class IncomeRepository
    {
        internal async static Task<List<Income>> GetIncomeAsync()
        {
            using (var db = new IncomeDBContext())
            {
                return await db.Income.ToListAsync();
            }
        }

        internal async static Task<Income> GetIncomeById(int month)
        {
            using (var db = new IncomeDBContext())
            {
                return await db.Income.FirstOrDefaultAsync(budget => budget.IncomeId == month);
            }
        }

        internal async static Task<List<Income>> GetMonthlyIncome(int month)
        {
            using (var db = new IncomeDBContext())
            {
                return await db.Income.Where(income => income.Date.Month == month).ToListAsync();
            }
        }

        internal async static Task<bool> CreateIncomeAsync(Income expenseToCreate)
        {
            using (var db = new IncomeDBContext())
            {
                try
                {
                    db.Income.AddAsync(expenseToCreate);

                    return await db.SaveChangesAsync() >= 1;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        internal async static Task<bool> UpdateIncomeAsync(Income expenseToUpdate)
        {
            using (var db = new IncomeDBContext())
            {
                try
                {
                    db.Income.Update(expenseToUpdate);

                    return await db.SaveChangesAsync() >= 1;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        internal async static Task<bool> DeleteIncomeAsync(int expenseId)
        {
            using (var db = new IncomeDBContext())
            {
                try
                {
                    Income postToDelete = await GetIncomeById(expenseId);

                    db.Income.Remove(postToDelete);

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
