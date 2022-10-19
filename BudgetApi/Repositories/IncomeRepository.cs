using Microsoft.EntityFrameworkCore;

namespace BudgetApi.Data
{
    internal static class IncomeRepository
    {
        internal async static Task<List<Income>> GetIncomeAsync()
        {
            using (var db = new BudgetDBContext())
            {
                return await db.Income.ToListAsync();
            }
        }

        internal async static Task<Income> GetIncomeById(Guid incomeID)
        {
            using (var db = new BudgetDBContext())
            {
                return await db.Income.FirstOrDefaultAsync(budget => budget.IncomeID == incomeID);
            }
        }

        internal async static Task<List<Income>> GetMonthlyIncome(int month)
        {
            using (var db = new BudgetDBContext())
            {
                return await db.Income.Where(income => income.Date.Month == month).ToListAsync();
            }
        }

        internal async static Task<bool> CreateIncomeAsync(Income incomeToCreate)
        {
            using (var db = new BudgetDBContext())
            {
                try
                {
                    db.Income.AddAsync(incomeToCreate);

                    return await db.SaveChangesAsync() >= 1;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        internal async static Task<bool> UpdateIncomeAsync(Income incomeToUpdate)
        {
            using (var db = new BudgetDBContext())
            {
                try
                {
                    db.Income.Update(incomeToUpdate);

                    return await db.SaveChangesAsync() >= 1;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        internal async static Task<bool> DeleteIncomeAsync(Guid incomeId)
        {
            using (var db = new BudgetDBContext())
            {
                try
                {
                    Income postToDelete = await GetIncomeById(incomeId);

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
