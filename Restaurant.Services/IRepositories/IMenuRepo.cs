using Restaurant.Entities.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Services.IRepositories
{
    public interface IMenuRepo
    {
        Task<List<MenuItem>> GetAllAsync( string? filteron,  string? filterQuery,  string? sortBy,  bool? isAscending,  int pageNumber = 1,  int pageSize = 1000);

        Task<MenuItem?> GetByIdAsync(int id);

        Task<MenuItem> CreateAsync(MenuItem menuItem);

        Task<MenuItem?> UpdateAsync(MenuItem menuItem, int id);

        Task<MenuItem?> DeleteAsync(int id);
    }
}
