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

        public async Task<List<MenuItem>> GetAllAsync(string? filteron, string? filterQuery, string? sortBy, bool? isAscending, int pageNumber = 1, int pageSize = 1000)
        {
           var meneus =  db.MenuItems
                .Include(o => o.OrderItems)
                .AsQueryable();

            // Filtering
            if (String.IsNullOrWhiteSpace(filteron) == false && String.IsNullOrWhiteSpace(filterQuery) == false)
            {
                if (filteron.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    meneus = meneus.Where(m => m.Name.Contains(filterQuery));
                }
            }

            // Sorting
            if (!string.IsNullOrWhiteSpace(sortBy))
            {
                if (sortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    meneus = isAscending == true
                        ? meneus.OrderBy(m => m.Name)
                        : meneus.OrderByDescending(m => m.Name);
                }
                else if (sortBy.Equals("Price", StringComparison.OrdinalIgnoreCase))
                {
                    meneus = isAscending == true
                        ? meneus.OrderBy(m => m.Price)
                        : meneus.OrderByDescending(m => m.Price);
                }
            }

            // Pagination
            var skipResults = (pageNumber - 1) * pageSize;

            return await meneus.Skip(skipResults).Take(pageSize).ToListAsync();
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
