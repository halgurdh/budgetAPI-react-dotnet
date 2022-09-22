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

        internal async static Task<Total> GetTotalById(int month)
        {
            using (var db = new TotalDBContext())
            {
                return await db.Total.FirstOrDefaultAsync(budget => budget.TotalId == month);
            }
        }

        internal async static Task<Total> GetMonthlyTotal(int month)
        {
            using (var db = new TotalDBContext())
            {
                var totalList = await db.Total.Where(total => total.Date.Month == month).ToListAsync();
                var totalObj = new Total();

                foreach (var total in totalList)
                {
                    if(total.TotalId == totalObj.TotalId)
                    {
                        double expense = total.Expenses.Value;
                        var allExpenses = expense + total.Expenses.Value;

                        double income = total.Income.Value;
                        var AllIncome = income + total.Income.Value;

                        if (totalObj.Expenses.Categories == total.Expenses.Categories)
                        {
                            totalObj.Date = total.Date;
                            totalObj.Name = total.Name;
                            totalObj.Value += total.Value;
                        }
                    }
                }

                return totalObj;
            }
        }

        internal async static Task<bool> CreateTotalAsync(Total totalToCreate)
        {
            using (var db = new TotalDBContext())
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

        internal async static Task<bool> UpdateTotalMonthAsync(int month)
        {
            using (var db = new TotalDBContext())
            {
                try
                {
                    Total totalToUpdate = await GetMonthlyTotal(month);

                    db.Total.Update(totalToUpdate);

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
            using (var db = new TotalDBContext())
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
