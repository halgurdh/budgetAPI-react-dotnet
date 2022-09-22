using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BudgetApi.Migrations.ExpensesDB
{
    public partial class income : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Expenses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Value = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenses", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Expenses",
                columns: new[] { "Id", "Date", "Name", "Value" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 9, 11, 12, 54, 35, 302, DateTimeKind.Local).AddTicks(6215), "testExpense", 0.0 },
                    { 2, new DateTime(2022, 9, 11, 12, 54, 35, 302, DateTimeKind.Local).AddTicks(6256), "testExpense", 0.0 },
                    { 3, new DateTime(2022, 9, 11, 12, 54, 35, 302, DateTimeKind.Local).AddTicks(6259), "testExpense", 0.0 },
                    { 4, new DateTime(2022, 9, 11, 12, 54, 35, 302, DateTimeKind.Local).AddTicks(6261), "testExpense", 0.0 },
                    { 5, new DateTime(2022, 9, 11, 12, 54, 35, 302, DateTimeKind.Local).AddTicks(6263), "testExpense", 0.0 },
                    { 6, new DateTime(2022, 9, 11, 12, 54, 35, 302, DateTimeKind.Local).AddTicks(6264), "testExpense", 0.0 },
                    { 7, new DateTime(2022, 9, 11, 12, 54, 35, 302, DateTimeKind.Local).AddTicks(6266), "testExpense", 0.0 },
                    { 8, new DateTime(2022, 9, 11, 12, 54, 35, 302, DateTimeKind.Local).AddTicks(6268), "testExpense", 0.0 },
                    { 9, new DateTime(2022, 9, 11, 12, 54, 35, 302, DateTimeKind.Local).AddTicks(6269), "testExpense", 0.0 },
                    { 10, new DateTime(2022, 9, 11, 12, 54, 35, 302, DateTimeKind.Local).AddTicks(6271), "testExpense", 0.0 },
                    { 11, new DateTime(2022, 9, 11, 12, 54, 35, 302, DateTimeKind.Local).AddTicks(6273), "testExpense", 0.0 },
                    { 12, new DateTime(2022, 9, 11, 12, 54, 35, 302, DateTimeKind.Local).AddTicks(6275), "testExpense", 0.0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Expenses");
        }
    }
}
