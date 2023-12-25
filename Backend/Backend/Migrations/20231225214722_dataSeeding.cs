using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class dataSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 1, "Electronics" },
                    { 2, "Furniture" },
                    { 3, "Clothing" },
                    { 4, "Books" },
                    { 5, "Home Appliances" }
                });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Dni", "EmailAddress", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 42000000, "betorc@gsc.com", "Beto", "341123456" },
                    { 42123456, "walter@gsc.com", "Walter", "341654321" },
                    { 42125750, "adrielgorosito14@gmail.com", "Adriel", "3476123456" }
                });

            migrationBuilder.InsertData(
                table: "Things",
                columns: new[] { "Id", "CategoryId", "Description" },
                values: new object[,]
                {
                    { 1, 1, "Notebook" },
                    { 2, 1, "Smartphone" },
                    { 3, 2, "Sofa" },
                    { 4, 3, "T-shirt" },
                    { 5, 3, "Jeans" },
                    { 6, 3, "Sweater" },
                    { 7, 3, "Socks" },
                    { 8, 3, "Shorts" },
                    { 9, 5, "Speaker" }
                });

            migrationBuilder.InsertData(
                table: "Loans",
                columns: new[] { "Id", "Date", "PersonDni", "ReturnDate", "ThingId" },
                values: new object[,]
                {
                    { 1, new DateOnly(2023, 12, 1), 42125750, new DateOnly(2023, 12, 5), 1 },
                    { 2, new DateOnly(2023, 12, 2), 42000000, null, 2 },
                    { 3, new DateOnly(2023, 12, 3), 42123456, new DateOnly(2023, 12, 7), 3 },
                    { 4, new DateOnly(2023, 12, 4), 42125750, null, 4 },
                    { 5, new DateOnly(2023, 12, 5), 42000000, null, 5 },
                    { 6, new DateOnly(2023, 12, 6), 42123456, null, 6 },
                    { 7, new DateOnly(2023, 12, 7), 42125750, new DateOnly(2023, 12, 11), 7 },
                    { 8, new DateOnly(2023, 12, 8), 42000000, null, 8 },
                    { 9, new DateOnly(2023, 12, 9), 42123456, new DateOnly(2023, 12, 13), 9 },
                    { 10, new DateOnly(2023, 12, 10), 42125750, null, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Loans",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Loans",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Loans",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Loans",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Loans",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Loans",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Loans",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Loans",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Loans",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Loans",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Dni",
                keyValue: 42000000);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Dni",
                keyValue: 42123456);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Dni",
                keyValue: 42125750);

            migrationBuilder.DeleteData(
                table: "Things",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Things",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Things",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Things",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Things",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Things",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Things",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Things",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Things",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
