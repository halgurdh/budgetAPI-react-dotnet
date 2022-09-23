using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BudgetApi.Data
{
    internal static class CategoryRepository
    {
        internal async static Task<List<Category>> GetExpenseAsync()
        {
            using (var db = new BudgetDBContext())
            {
                return await db.Category.ToListAsync();
            }
        }
    }
}
