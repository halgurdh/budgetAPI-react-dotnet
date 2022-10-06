using BudgetApi.Data;

namespace BudgetApi.Services
{
    public class CategoryService
    {
        public void CategoryBuilder(WebApplication app)
        {
            app.MapGet("/getAllCategories", async () => await CategoryRepository.GetCategoriesAsync())
            .WithTags("Category EndPoints");

            app.MapGet("/getCategoryById/{CategoryId}", async (Guid CategoryId) =>
            {
                Category CategoryToReturn = await CategoryRepository.GetCategoryById(CategoryId);

                if (CategoryToReturn != null)
                {
                    return Results.Ok(CategoryToReturn);
                }
                else
                {
                    return Results.BadRequest();
                }

            }).WithTags("Category EndPoints");

            app.MapPost("/createCategory", async (Category CategoryToCreate) =>
            {
                bool createSuccessful = await CategoryRepository.CreateCategoryAsync(CategoryToCreate);

                if (createSuccessful)
                {
                    return Results.Ok("Create Successful");
                }
                else
                {
                    return Results.BadRequest();
                }

            }).WithTags("Category EndPoints");

            app.MapPut("/updateCategory", async (Category CategoryToUpdate) =>
            {
                bool updateSuccessful = await CategoryRepository.UpdateCategoryAsync(CategoryToUpdate);

                if (updateSuccessful)
                {
                    return Results.Ok("Update Successful");
                }
                else
                {
                    return Results.BadRequest();
                }

            }).WithTags("Category EndPoints");

            app.MapDelete("/deleteCategoryById/{CategoryId}", async (Guid CategoryId) =>
            {
                bool deleteSuccessful = await CategoryRepository.DeleteCategoryAsync(CategoryId);

                if (deleteSuccessful)
                {
                    return Results.Ok("Delete Successful");
                }
                else
                {
                    return Results.BadRequest();
                }

            }).WithTags("Category EndPoints");
        }
    }
}
