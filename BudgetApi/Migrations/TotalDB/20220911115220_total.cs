using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BudgetApi.Migrations.TotalDB
{
    public partial class total : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Total",
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
                    table.PrimaryKey("PK_Total", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Total",
                columns: new[] { "Id", "Date", "Name", "Value" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 9, 11, 13, 52, 19, 953, DateTimeKind.Local).AddTicks(9810), "testTotal", 0.0 },
                    { 2, new DateTime(2022, 9, 11, 13, 52, 19, 953, DateTimeKind.Local).AddTicks(9842), "testTotal", 0.0 },
                    { 3, new DateTime(2022, 9, 11, 13, 52, 19, 953, DateTimeKind.Local).AddTicks(9845), "testTotal", 0.0 },
                    { 4, new DateTime(2022, 9, 11, 13, 52, 19, 953, DateTimeKind.Local).AddTicks(9847), "testTotal", 0.0 },
                    { 5, new DateTime(2022, 9, 11, 13, 52, 19, 953, DateTimeKind.Local).AddTicks(9848), "testTotal", 0.0 },
                    { 6, new DateTime(2022, 9, 11, 13, 52, 19, 953, DateTimeKind.Local).AddTicks(9850), "testTotal", 0.0 },
                    { 7, new DateTime(2022, 9, 11, 13, 52, 19, 953, DateTimeKind.Local).AddTicks(9852), "testTotal", 0.0 },
                    { 8, new DateTime(2022, 9, 11, 13, 52, 19, 953, DateTimeKind.Local).AddTicks(9854), "testTotal", 0.0 },
                    { 9, new DateTime(2022, 9, 11, 13, 52, 19, 953, DateTimeKind.Local).AddTicks(9856), "testTotal", 0.0 },
                    { 10, new DateTime(2022, 9, 11, 13, 52, 19, 953, DateTimeKind.Local).AddTicks(9858), "testTotal", 0.0 },
                    { 11, new DateTime(2022, 9, 11, 13, 52, 19, 953, DateTimeKind.Local).AddTicks(9859), "testTotal", 0.0 },
                    { 12, new DateTime(2022, 9, 11, 13, 52, 19, 953, DateTimeKind.Local).AddTicks(9861), "testTotal", 0.0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Total");
        }
    }
}
