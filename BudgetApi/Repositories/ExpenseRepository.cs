using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BudgetApi.Data
{
    internal static class ExpenseRepository
    {
        internal async static Task<List<Expenses>> GetExpenseAsync()
        {
            using (var db = new BudgetDBContext())
            {
                return await db.Expenses.ToListAsync();
            }
        }

        internal async static Task<Expenses> GetExpenseById(int expenseId)
        {
            using (var db = new BudgetDBContext())
            {
                return await db.Expenses.FirstOrDefaultAsync(expenses => expenses.ExpensesId == expenseId);
            }
        }

        internal async static Task<List<Expenses>> GetMonthlyExpenses(int month)
        {
            using (var db = new BudgetDBContext())
            {
                return await db.Expenses.Where(expenses => expenses.Date.Month == month).ToListAsync();
            }
        }

        internal async static Task<bool> CreateExpenseAsync(Expenses expenseToCreate)
        {
            using (var db = new BudgetDBContext())
            {
                try
                {
                    db.Expenses.AddAsync(expenseToCreate);

                    return await db.SaveChangesAsync() >= 1;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        internal async static Task<bool> UpdateExpenseAsync(Expenses expenseToUpdate)
        {
            using (var db = new BudgetDBContext())
            {
                try
                {
                    db.Expenses.Update(expenseToUpdate);

                    return await db.SaveChangesAsync() >= 1;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        internal async static Task<bool> DeleteExpenseAsync(int expenseId)
        {
            using (var db = new BudgetDBContext())
            {
                try
                {
                    Expenses postToDelete = await GetExpenseById(expenseId);

                    db.Expenses.Remove(postToDelete);

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
