using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Restaurant.Entities.Migrations
{
    /// <inheritdoc />
    public partial class SeededdataforMenuItemsandOrders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "MenuItems",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "Id", "Category", "Description", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Main", "Classic tomato and mozzarella pizza.", "https://example.com/pizza.jpg", "Margherita Pizza", 9.99m },
                    { 2, "Main", "Pasta with meat sauce.", "https://example.com/spaghetti.jpg", "Spaghetti Bolognese", 12.49m },
                    { 3, "Main", "Romaine lettuce, croutons, parmesan.", "https://example.com/salad.jpg", "Caesar Salad", 7.99m },
                    { 4, "Main", "Served with vegetables and rice.", "https://example.com/chicken.jpg", "Grilled Chicken", 11.99m },
                    { 5, "Main", "Beef patty with cheese, lettuce, tomato.", "https://example.com/burger.jpg", "Cheeseburger", 8.50m },
                    { 6, "Dessert", "Rich chocolate layered cake.", "https://example.com/cake.jpg", "Chocolate Cake", 4.75m },
                    { 7, "Dessert", "Two scoops of classic vanilla.", "https://example.com/icecream.jpg", "Vanilla Ice Cream", 3.99m },
                    { 8, "Drink", "Chilled soft drink (330ml).", "https://example.com/coke.jpg", "Coca-Cola", 1.99m },
                    { 9, "Drink", "Strong black coffee.", "https://example.com/espresso.jpg", "Espresso", 2.49m },
                    { 10, "Drink", "Freshly squeezed orange juice.", "https://example.com/juice.jpg", "Orange Juice", 2.99m }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "OrderDate", "Status", "TotalAmount" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed", 23.50m },
                    { 2, new DateTime(2025, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed", 45.00m },
                    { 3, new DateTime(2025, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cancelled", 12.75m },
                    { 4, new DateTime(2025, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending", 98.90m },
                    { 5, new DateTime(2025, 7, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed", 32.20m },
                    { 6, new DateTime(2025, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed", 61.99m },
                    { 7, new DateTime(2025, 7, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending", 18.00m },
                    { 8, new DateTime(2025, 7, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed", 70.15m },
                    { 9, new DateTime(2025, 7, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cancelled", 49.99m },
                    { 10, new DateTime(2025, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending", 25.50m },
                    { 11, new DateTime(2025, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed", 31.80m },
                    { 12, new DateTime(2025, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed", 42.00m },
                    { 13, new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending", 66.66m },
                    { 14, new DateTime(2025, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending", 15.00m },
                    { 15, new DateTime(2025, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed", 89.99m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "MenuItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
