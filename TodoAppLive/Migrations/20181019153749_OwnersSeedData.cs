using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TodoAppLive.Migrations
{
    public partial class OwnersSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Owners",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Neko" });

            migrationBuilder.InsertData(
                table: "Owners",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Jen" });

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 1,
                column: "DueDate",
                value: new DateTime(2018, 10, 19, 11, 37, 48, 425, DateTimeKind.Local));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 1,
                column: "DueDate",
                value: new DateTime(2018, 10, 19, 11, 13, 57, 903, DateTimeKind.Local));
        }
    }
}
