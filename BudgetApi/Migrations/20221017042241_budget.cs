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
                name: "Category",
                columns: table => new
                {
                    CategoryID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "Expenses",
                columns: table => new
                {
                    ExpensesID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Value = table.Column<double>(type: "float", nullable: false),
                    CategoryID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenses", x => x.ExpensesID);
                    table.ForeignKey(
                        name: "FK_Expenses_Category_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Income",
                columns: table => new
                {
                    IncomeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Value = table.Column<double>(type: "float", nullable: false),
                    CategoryID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Income", x => x.IncomeID);
                    table.ForeignKey(
                        name: "FK_Income_Category_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Total",
                columns: table => new
                {
                    TotalID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Value = table.Column<double>(type: "float", nullable: false),
                    CategoryID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Total", x => x.TotalID);
                    table.ForeignKey(
                        name: "FK_Total_Category_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryID", "Name" },
                values: new object[] { new Guid("0a6a6fc1-6f93-4e81-b3a3-bfebdb7a3857"), "Salary" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryID", "Name" },
                values: new object[] { new Guid("6820cbeb-ccd5-4c85-99f9-2547185d16d4"), "Rent" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryID", "Name" },
                values: new object[] { new Guid("faf74050-74b9-449f-a817-11b30078dc2f"), "Other" });

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_CategoryID",
                table: "Expenses",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Income_CategoryID",
                table: "Income",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Total_CategoryID",
                table: "Total",
                column: "CategoryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Expenses");

            migrationBuilder.DropTable(
                name: "Income");

            migrationBuilder.DropTable(
                name: "Total");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
