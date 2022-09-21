using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BudgetApi.Migrations
{
    public partial class income : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Income",
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
                    table.PrimaryKey("PK_Income", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Income",
                columns: new[] { "Id", "Date", "Name", "Value" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 9, 11, 12, 54, 12, 329, DateTimeKind.Local).AddTicks(758), "testIncome", 0.0 },
                    { 2, new DateTime(2022, 9, 11, 12, 54, 12, 329, DateTimeKind.Local).AddTicks(795), "testIncome", 0.0 },
                    { 3, new DateTime(2022, 9, 11, 12, 54, 12, 329, DateTimeKind.Local).AddTicks(797), "testIncome", 0.0 },
                    { 4, new DateTime(2022, 9, 11, 12, 54, 12, 329, DateTimeKind.Local).AddTicks(798), "testIncome", 0.0 },
                    { 5, new DateTime(2022, 9, 11, 12, 54, 12, 329, DateTimeKind.Local).AddTicks(800), "testIncome", 0.0 },
                    { 6, new DateTime(2022, 9, 11, 12, 54, 12, 329, DateTimeKind.Local).AddTicks(801), "testIncome", 0.0 },
                    { 7, new DateTime(2022, 9, 11, 12, 54, 12, 329, DateTimeKind.Local).AddTicks(803), "testIncome", 0.0 },
                    { 8, new DateTime(2022, 9, 11, 12, 54, 12, 329, DateTimeKind.Local).AddTicks(804), "testIncome", 0.0 },
                    { 9, new DateTime(2022, 9, 11, 12, 54, 12, 329, DateTimeKind.Local).AddTicks(806), "testIncome", 0.0 },
                    { 10, new DateTime(2022, 9, 11, 12, 54, 12, 329, DateTimeKind.Local).AddTicks(808), "testIncome", 0.0 },
                    { 11, new DateTime(2022, 9, 11, 12, 54, 12, 329, DateTimeKind.Local).AddTicks(809), "testIncome", 0.0 },
                    { 12, new DateTime(2022, 9, 11, 12, 54, 12, 329, DateTimeKind.Local).AddTicks(810), "testIncome", 0.0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Income");
        }
    }
}
