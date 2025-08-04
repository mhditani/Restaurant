using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Restaurant.Entities.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Entities.Data
{
    public class RestaurantDbContext : IdentityDbContext
    {
        public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options) : base(options)
        {
        }

        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }





        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ✅ Static seed data for Orders (NO DateTime.Now)
            modelBuilder.Entity<Order>().HasData(
                new Order { Id = 1, OrderDate = new DateTime(2025, 07, 20), TotalAmount = 23.50m, Status = "Completed" },
                new Order { Id = 2, OrderDate = new DateTime(2025, 07, 21), TotalAmount = 45.00m, Status = "Completed" },
                new Order { Id = 3, OrderDate = new DateTime(2025, 07, 22), TotalAmount = 12.75m, Status = "Cancelled" },
                new Order { Id = 4, OrderDate = new DateTime(2025, 07, 23), TotalAmount = 98.90m, Status = "Pending" },
                new Order { Id = 5, OrderDate = new DateTime(2025, 07, 24), TotalAmount = 32.20m, Status = "Completed" },
                new Order { Id = 6, OrderDate = new DateTime(2025, 07, 25), TotalAmount = 61.99m, Status = "Completed" },
                new Order { Id = 7, OrderDate = new DateTime(2025, 07, 26), TotalAmount = 18.00m, Status = "Pending" },
                new Order { Id = 8, OrderDate = new DateTime(2025, 07, 27), TotalAmount = 70.15m, Status = "Completed" },
                new Order { Id = 9, OrderDate = new DateTime(2025, 07, 28), TotalAmount = 49.99m, Status = "Cancelled" },
                new Order { Id = 10, OrderDate = new DateTime(2025, 07, 29), TotalAmount = 25.50m, Status = "Pending" },
                new Order { Id = 11, OrderDate = new DateTime(2025, 07, 30), TotalAmount = 31.80m, Status = "Completed" },
                new Order { Id = 12, OrderDate = new DateTime(2025, 07, 31), TotalAmount = 42.00m, Status = "Completed" },
                new Order { Id = 13, OrderDate = new DateTime(2025, 08, 01), TotalAmount = 66.66m, Status = "Pending" },
                new Order { Id = 14, OrderDate = new DateTime(2025, 08, 02), TotalAmount = 15.00m, Status = "Pending" },
                new Order { Id = 15, OrderDate = new DateTime(2025, 08, 03), TotalAmount = 89.99m, Status = "Completed" }
            );

            // ✅ Seed data for MenuItems
            modelBuilder.Entity<MenuItem>().HasData(
                new MenuItem { Id = 1, Name = "Margherita Pizza", Description = "Classic tomato and mozzarella pizza.", Price = 9.99m, Category = "Main", ImageUrl = "https://example.com/pizza.jpg" },
                new MenuItem { Id = 2, Name = "Spaghetti Bolognese", Description = "Pasta with meat sauce.", Price = 12.49m, Category = "Main", ImageUrl = "https://example.com/spaghetti.jpg" },
                new MenuItem { Id = 3, Name = "Caesar Salad", Description = "Romaine lettuce, croutons, parmesan.", Price = 7.99m, Category = "Main", ImageUrl = "https://example.com/salad.jpg" },
                new MenuItem { Id = 4, Name = "Grilled Chicken", Description = "Served with vegetables and rice.", Price = 11.99m, Category = "Main", ImageUrl = "https://example.com/chicken.jpg" },
                new MenuItem { Id = 5, Name = "Cheeseburger", Description = "Beef patty with cheese, lettuce, tomato.", Price = 8.50m, Category = "Main", ImageUrl = "https://example.com/burger.jpg" },
                new MenuItem { Id = 6, Name = "Chocolate Cake", Description = "Rich chocolate layered cake.", Price = 4.75m, Category = "Dessert", ImageUrl = "https://example.com/cake.jpg" },
                new MenuItem { Id = 7, Name = "Vanilla Ice Cream", Description = "Two scoops of classic vanilla.", Price = 3.99m, Category = "Dessert", ImageUrl = "https://example.com/icecream.jpg" },
                new MenuItem { Id = 8, Name = "Coca-Cola", Description = "Chilled soft drink (330ml).", Price = 1.99m, Category = "Drink", ImageUrl = "https://example.com/coke.jpg" },
                new MenuItem { Id = 9, Name = "Espresso", Description = "Strong black coffee.", Price = 2.49m, Category = "Drink", ImageUrl = "https://example.com/espresso.jpg" },
                new MenuItem { Id = 10, Name = "Orange Juice", Description = "Freshly squeezed orange juice.", Price = 2.99m, Category = "Drink", ImageUrl = "https://example.com/juice.jpg" }
            );

            var clientId = "ceb5cc38-1ad1-45a9-91cf-16b02d951f28";
            var adminId = "603ef395-3129-4326-8c3b-8a2c5aa2225f";

            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                   Id = clientId,
                   ConcurrencyStamp = clientId,
                   Name = "Client",
                   NormalizedName = "Client".ToUpper()
                },
                new IdentityRole
                {
                    Id = adminId,
                    ConcurrencyStamp = adminId,
                    Name = "Admin",
                    NormalizedName = "Admin".ToUpper(),
                }
            };

            modelBuilder.Entity<IdentityRole>().HasData( roles );

        }

    }
}
