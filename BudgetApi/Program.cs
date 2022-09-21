using Microsoft.OpenApi.Models;
using BudgetApi.Data;
using BudgetApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("CORSPolicy",
        builder =>
        {
            builder
            .AllowAnyMethod()
            .AllowAnyHeader()
            .WithOrigins("http://localhost:3000", "https://appname.azure.net");
        });
});

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(SwaggerGenOptions =>
{
    SwaggerGenOptions.SwaggerDoc("v1", new OpenApiInfo { Title = "ASP.Net + React Budgeting App", Version = "v1" });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(swaggerUIOptions =>
{
    swaggerUIOptions.DocumentTitle = "APS.NET + React Budgetting App";
    swaggerUIOptions.SwaggerEndpoint("/swagger/v1/swagger.json", "Web API budgeting model");
    swaggerUIOptions.RoutePrefix = string.Empty;
});

app.UseHttpsRedirection();

app.UseCors("CORSPolicy");

ExpensesService expensesService = new ExpensesService();
expensesService.ExpenseBuilder(app);

IncomeService incomeService = new IncomeService();
incomeService.IncomeBuilder(app);

TotalService TotalService = new TotalService();
TotalService.TotalBuilder(app);

app.Run();
