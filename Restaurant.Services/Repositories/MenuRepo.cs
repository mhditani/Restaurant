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
    public class MenuRepo : IMenuRepo
    {
        private readonly RestaurantDbContext db;

        public MenuRepo(RestaurantDbContext db)
        {
            this.db = db;
        }

        public async Task<MenuItem> CreateAsync(MenuItem menuItem)
        {
            await db.MenuItems.AddAsync(menuItem);
            await db.SaveChangesAsync();
            return menuItem;
        }

        public async Task<MenuItem?> DeleteAsync(int id)
        {
            var existingMenu = await db.MenuItems.FirstOrDefaultAsync(m => m.Id == id); 
            if (existingMenu == null)
            {
                return null;
            }
            db.MenuItems.Remove(existingMenu);
            await db.SaveChangesAsync();
            return existingMenu;
        }

        public async Task<List<MenuItem>> GetAllAsync()
        {
           return await db.MenuItems
                .Include("OrderItems")
                .ToListAsync();
        }

        public async Task<MenuItem?> GetByIdAsync(int id)
        {
            return await db.MenuItems
                .Include(o => o.OrderItems)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<MenuItem?> UpdateAsync(MenuItem menuItem, int id)
        {
            var existingMenuDomain = await db.MenuItems
                .Include(o => o.OrderItems)
                .FirstOrDefaultAsync(m => m.Id == id); 

            if (existingMenuDomain == null)
            {
                return null;
            }

            existingMenuDomain.Name = menuItem.Name;
            existingMenuDomain.Description = menuItem.Description;
            existingMenuDomain.Price = menuItem.Price;
            existingMenuDomain.Category = menuItem.Category;
            existingMenuDomain.ImageUrl = menuItem.ImageUrl;
           

            await db.SaveChangesAsync();
            return existingMenuDomain;
        }
    }
}
