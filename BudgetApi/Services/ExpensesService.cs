using BudgetApi.Data;

namespace BudgetApi.Services
{
    public class ExpensesService
    {
        public void ExpenseBuilder(WebApplication app)
        {
            app.MapGet("/getAllExpenses", async () => await ExpenseRepository.GetExpenseAsync())
            .WithTags("Expenses EndPoints");

            app.MapGet("/getExpenseById/{expenseId}", async (Guid expenseId) =>
            {
                Expenses expenseToReturn = await ExpenseRepository.GetExpenseById(expenseId);

                if (expenseToReturn != null)
                {
                    return Results.Ok(expenseToReturn);
                }
                else
                {
                    return Results.BadRequest();
                }

            }).WithTags("Expenses EndPoints");

            app.MapGet("/getMonthlyExpense/{month}", async (int month) =>
            {
                List<Expenses> expenseToReturn = await ExpenseRepository.GetMonthlyExpenses(month);

                if (expenseToReturn != null)
                {
                    return Results.Ok(expenseToReturn);
                }
                else
                {
                    return Results.BadRequest();
                }

            }).WithTags("Expenses EndPoints");

            app.MapPost("/createExpense", async (Expenses expenseToCreate) =>
            {
                bool createSuccessful = await ExpenseRepository.CreateExpenseAsync(expenseToCreate);

                if (createSuccessful)
                {
                    return Results.Ok("Create Successful");
                }
                else
                {
                    return Results.BadRequest();
                }


            }).WithTags("Expenses EndPoints");

            app.MapPut("/updateExpense", async (Expenses expenseToUpdate) =>
            {
                bool updateSuccessful = await ExpenseRepository.UpdateExpenseAsync(expenseToUpdate);

                if (updateSuccessful)
                {
                    return Results.Ok("Update Successful");
                }
                else
                {
                    return Results.BadRequest();
                }

            }).WithTags("Expenses EndPoints");


            app.MapDelete("/deleteExpenseById/{expenseId}", async (Guid expenseId) =>
            {
                bool deleteSuccessful = await ExpenseRepository.DeleteExpenseAsync(expenseId);

                if (deleteSuccessful)
                {
                    return Results.Ok("Delete Successful");
                }
                else
                {
                    return Results.BadRequest();
                }

            }).WithTags("Expenses EndPoints");
        }
    }
}
