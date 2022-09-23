using Microsoft.EntityFrameworkCore;

namespace BudgetApi.Data
{
    internal static class TotalRepository
    {
        internal async static Task<List<Total>> GetTotalAsync()
        {
            using (var db = new BudgetDBContext())
            {
                return await db.Total.ToListAsync();
            }
        }

        internal async static Task<Total> GetTotalById(int month)
        {
            using (var db = new BudgetDBContext())
            {
                return await db.Total.FirstOrDefaultAsync(budget => budget.TotalId == month);
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

        internal async static Task<bool> DeleteTotalAsync(int totalId)
        {
            using (var db = new BudgetDBContext())
            {
                try
                {
                    Total postToDelete = await GetTotalById(totalId);

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
