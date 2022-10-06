using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BudgetApi.Data
{
    internal static class CategoryRepository
    {
        internal async static Task<List<Category>> GetCategoriesAsync()
        {
            using (var db = new BudgetDBContext())
            {
                return await db.Category.ToListAsync();
            }
        }

        internal async static Task<Category> GetCategoryById(Guid CategoryId)
        {
            using (var db = new BudgetDBContext())
            {
                return await db.Category.FirstOrDefaultAsync(Category => Category.CategoryID == CategoryId);
            }
        }

        internal async static Task<bool> CreateCategoryAsync(Category CategoryToCreate)
        {
            using (var db = new BudgetDBContext())
            {
                try
                {
                    db.Category.AddAsync(CategoryToCreate);

                    return await db.SaveChangesAsync() >= 1;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        internal async static Task<bool> UpdateCategoryAsync(Category CategoryToUpdate)
        {
            using (var db = new BudgetDBContext())
            {
                try
                {
                    db.Category.Update(CategoryToUpdate);

                    return await db.SaveChangesAsync() >= 1;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        internal async static Task<bool> DeleteCategoryAsync(Guid CategoryId)
        {
            using (var db = new BudgetDBContext())
            {
                try
                {
                    Category postToDelete = await GetCategoryById(CategoryId);

                    db.Category.Remove(postToDelete);

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
