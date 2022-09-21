using Microsoft.EntityFrameworkCore;

namespace BudgetApi.Data
{
    internal static class ExpenseRepository
    {
        internal async static Task<List<Expenses>> GetExpenseAsync()
        {
            using (var db = new ExpensesDBContext())
            {
                return await db.Expenses.ToListAsync();
            }
        }

        internal async static Task<Expenses> GetMonthlyExpenseById(int month)
        {
            using (var db = new ExpensesDBContext())
            {
                return await db.Expenses.FirstOrDefaultAsync(budget => budget.Id == month);
            }
        }

        internal async static Task<bool> CreateExpenseAsync(Expenses expenseToCreate)
        {
            using (var db = new ExpensesDBContext())
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
            using (var db = new ExpensesDBContext())
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
            using (var db = new ExpensesDBContext())
            {
                try
                {
                    Expenses postToDelete = await GetMonthlyExpenseById(expenseId);

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
