using Microsoft.EntityFrameworkCore;

namespace BudgetApi.Data
{
    internal static class TotalRepository
    {
        internal async static Task<List<Total>> GetTotalAsync()
        {
            using (var db = new TotalDBContext())
            {
                return await db.Total.ToListAsync();
            }
        }

        internal async static Task<Total> GetMonthlyTotalById(int month)
        {
            using (var db = new TotalDBContext())
            {
                return await db.Total.FirstOrDefaultAsync(budget => budget.Id == month);
            }
        }

        internal async static Task<bool> CreateTotalAsync(Total expenseToCreate)
        {
            using (var db = new TotalDBContext())
            {
                try
                {
                    db.Total.AddAsync(expenseToCreate);

                    return await db.SaveChangesAsync() >= 1;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        internal async static Task<bool> UpdateTotalAsync(Total expenseToUpdate)
        {
            using (var db = new TotalDBContext())
            {
                try
                {
                    db.Total.Update(expenseToUpdate);

                    return await db.SaveChangesAsync() >= 1;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        internal async static Task<bool> DeleteTotalAsync(int expenseId)
        {
            using (var db = new TotalDBContext())
            {
                try
                {
                    Total postToDelete = await GetMonthlyTotalById(expenseId);

                    db.Total.Remove(postToDelete);

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
