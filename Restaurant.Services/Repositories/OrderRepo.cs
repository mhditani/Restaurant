using Microsoft.EntityFrameworkCore;
using Restaurant.Entities.Data;
using Restaurant.Entities.Domain;
using Restaurant.Services.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Services.Repositories
{
    public class OrderRepo : IOrderRepo
    {
        private readonly RestaurantDbContext db;

        public OrderRepo(RestaurantDbContext db)
        {
            this.db = db;
        }



        public async Task<Order> CreateAsync(Order order)
        {
            // ✅ Set server-side default values:
            order.OrderDate = DateTime.Now;
            order.Status = "Pending";
            order.TotalAmount = order.OrderItems.Sum(i => i.Quantity * i.UnitPrice);

            await db.Orders.AddAsync(order);
            await db.SaveChangesAsync();
            return order;
        }


        public async Task<Order?> DeleteAsync(int id)
        {
            var existingOrder = await db.Orders
                .Include(o => o.OrderItems)
                .FirstOrDefaultAsync(o => o.Id == id);

            if (existingOrder == null) return null;

            db.OrderItems.RemoveRange(existingOrder.OrderItems); // remove related items first
            db.Orders.Remove(existingOrder);

            await db.SaveChangesAsync();
            return existingOrder;
        }

        public async Task<List<Order>> GetAllAsync(
    string? status,
    DateTime? startDate,
    DateTime? endDate,
    string? sortBy,
    bool? isAscending,
    int pageNumber = 1,
    int pageSize = 10)
        {
            var orders = db.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.MenuItem)  // optional
                .AsQueryable();

            // Filtering by status
            if (!string.IsNullOrWhiteSpace(status))
            {
                orders = orders.Where(o => o.Status.Equals(status, StringComparison.OrdinalIgnoreCase));
            }

            // Filtering by date range
            if (startDate.HasValue)
            {
                orders = orders.Where(o => o.OrderDate >= startDate.Value);
            }
            if (endDate.HasValue)
            {
                orders = orders.Where(o => o.OrderDate <= endDate.Value);
            }

            // Sorting
            if (!string.IsNullOrWhiteSpace(sortBy))
            {
                if (sortBy.Equals("orderDate", StringComparison.OrdinalIgnoreCase))
                {
                    orders = isAscending == true
                        ? orders.OrderBy(o => o.OrderDate)
                        : orders.OrderByDescending(o => o.OrderDate);
                }
                else if (sortBy.Equals("totalAmount", StringComparison.OrdinalIgnoreCase))
                {
                    orders = isAscending == true
                        ? orders.OrderBy(o => o.TotalAmount)
                        : orders.OrderByDescending(o => o.TotalAmount);
                }
                else if (sortBy.Equals("status", StringComparison.OrdinalIgnoreCase))
                {
                    orders = isAscending == true
                        ? orders.OrderBy(o => o.Status)
                        : orders.OrderByDescending(o => o.Status);
                }
            }

            // Pagination
            var skip = (pageNumber - 1) * pageSize;
            return await orders.Skip(skip).Take(pageSize).ToListAsync();
        }

        public async Task<Order?> GetByIdAsync(int id)
        {
            var orderDomain = await db.Orders
                .Include(o => o.OrderItems)
                .FirstOrDefaultAsync(o => o.Id == id);

            return orderDomain;
        }

        public async Task<Order?> UpdateAsync(Order order, int id)
        {
            var existingOrder = await db.Orders.FindAsync(id);
            if (existingOrder == null) return null;

            existingOrder.Status = order.Status;

            await db.SaveChangesAsync();
            return existingOrder;
        }
    }
}
