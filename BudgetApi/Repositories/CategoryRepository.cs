using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BudgetApi.Data
{
    internal static class CategoryRepository
    {
        internal async static Task<List<Category>> GetExpenseAsync()
        {
            using (var db = new CategoryDBContext())
            {
                return await db.Category.ToListAsync();
            }
        }
    }
}
