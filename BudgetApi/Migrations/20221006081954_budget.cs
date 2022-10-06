using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BudgetApi.Migrations
{
    public partial class budget : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Expenses",
                columns: table => new
                {
                    ExpensesID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Value = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenses", x => x.ExpensesID);
                });

            migrationBuilder.CreateTable(
                name: "Income",
                columns: table => new
                {
                    IncomeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Value = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Income", x => x.IncomeID);
                });

            migrationBuilder.CreateTable(
                name: "Total",
                columns: table => new
                {
                    TotalID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Value = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Total", x => x.TotalID);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpensesID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IncomeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TotalID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryID);
                    table.ForeignKey(
                        name: "FK_Category_Expenses_ExpensesID",
                        column: x => x.ExpensesID,
                        principalTable: "Expenses",
                        principalColumn: "ExpensesID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Category_Income_IncomeID",
                        column: x => x.IncomeID,
                        principalTable: "Income",
                        principalColumn: "IncomeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Category_Total_TotalID",
                        column: x => x.TotalID,
                        principalTable: "Total",
                        principalColumn: "TotalID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Expenses",
                columns: new[] { "ExpensesID", "Date", "Name", "Value" },
                values: new object[] { new Guid("49c37889-c7fc-4d0e-8892-1be05ff2735d"), new DateTime(2022, 10, 6, 10, 19, 54, 756, DateTimeKind.Local).AddTicks(9715), "Appartment", 670.0 });

            migrationBuilder.InsertData(
                table: "Income",
                columns: new[] { "IncomeID", "Date", "Name", "Value" },
                values: new object[] { new Guid("7589e453-227a-425b-bffa-6c260faa5bc2"), new DateTime(2022, 10, 6, 10, 19, 54, 756, DateTimeKind.Local).AddTicks(9749), "Money B.V", 2950.0 });

            migrationBuilder.InsertData(
                table: "Total",
                columns: new[] { "TotalID", "Date", "Name", "Value" },
                values: new object[] { new Guid("636bf07e-d900-4f64-87b7-f46efaa8e90f"), new DateTime(2022, 10, 6, 10, 19, 54, 756, DateTimeKind.Local).AddTicks(9752), "Money B.V", 2280.0 });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryID", "ExpensesID", "IncomeID", "Name", "TotalID" },
                values: new object[] { new Guid("1025d791-fc45-4373-8de7-2ba547b873e0"), new Guid("49c37889-c7fc-4d0e-8892-1be05ff2735d"), new Guid("7589e453-227a-425b-bffa-6c260faa5bc2"), "Rent", new Guid("636bf07e-d900-4f64-87b7-f46efaa8e90f") });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryID", "ExpensesID", "IncomeID", "Name", "TotalID" },
                values: new object[] { new Guid("e2b53e13-9ce2-4e1c-aeb9-05faf7c4f461"), new Guid("49c37889-c7fc-4d0e-8892-1be05ff2735d"), new Guid("7589e453-227a-425b-bffa-6c260faa5bc2"), "Salary", new Guid("636bf07e-d900-4f64-87b7-f46efaa8e90f") });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryID", "ExpensesID", "IncomeID", "Name", "TotalID" },
                values: new object[] { new Guid("faeec15d-c9c9-47f6-9453-3dace77ef237"), new Guid("49c37889-c7fc-4d0e-8892-1be05ff2735d"), new Guid("7589e453-227a-425b-bffa-6c260faa5bc2"), "Other", new Guid("636bf07e-d900-4f64-87b7-f46efaa8e90f") });

            migrationBuilder.CreateIndex(
                name: "IX_Category_ExpensesID",
                table: "Category",
                column: "ExpensesID");

            migrationBuilder.CreateIndex(
                name: "IX_Category_IncomeID",
                table: "Category",
                column: "IncomeID");

            migrationBuilder.CreateIndex(
                name: "IX_Category_TotalID",
                table: "Category",
                column: "TotalID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Expenses");

            migrationBuilder.DropTable(
                name: "Income");

            migrationBuilder.DropTable(
                name: "Total");
        }
    }
}
