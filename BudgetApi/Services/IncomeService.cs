using BudgetApi.Data;

namespace BudgetApi.Services
{
    public class IncomeService
    {
        public void IncomeBuilder(WebApplication app)
        {
            app.MapGet("/getAllIncome", async () => await IncomeRepository.GetIncomeAsync())
            .WithTags("income EndPoints");

            app.MapGet("/getIncomeById/{incomeId}", async (int incomeId) =>
            {
                Income incomeToReturn = await IncomeRepository.GetMonthlyIncomeById(incomeId);

                if (incomeToReturn != null)
                {
                    return Results.Ok(incomeToReturn);
                }
                else
                {
                    return Results.BadRequest();
                }

            }).WithTags("Income EndPoints");

            app.MapPost("/createIncome", async (Income incomeToCreate) =>
            {
                bool createSuccessful = await IncomeRepository.CreateIncomeAsync(incomeToCreate);

                if (createSuccessful)
                {
                    return Results.Ok("Create Successful");
                }
                else
                {
                    return Results.BadRequest();
                }

            }).WithTags("Income EndPoints");

            app.MapPut("/updateIncome", async (Income incomeToUpdate) =>
            {
                bool updateSuccessful = await IncomeRepository.UpdateIncomeAsync(incomeToUpdate);

                if (updateSuccessful)
                {
                    return Results.Ok("Update Successful");
                }
                else
                {
                    return Results.BadRequest();
                }

            }).WithTags("Income EndPoints");


            app.MapDelete("/deleteIncomeById/{incomeId}", async (int incomeId) =>
            {
                bool deleteSuccessful = await IncomeRepository.DeleteIncomeAsync(incomeId);

                if (deleteSuccessful)
                {
                    return Results.Ok("Delete Successful");
                }
                else
                {
                    return Results.BadRequest();
                }

            }).WithTags("Income EndPoints");
        }
    }
}
