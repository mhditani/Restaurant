using Restaurant.Entities.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Services.IRepositories
{
    public interface IOrderRepo
    {
        Task<List<Order>> GetAllAsync(
            string? status,
            DateTime? startDate,
            DateTime? endDate,
            string? sortBy,
            bool? isAscending,
            int pageNumber = 1,
            int pageSize = 1000);
        Task<Order?> GetByIdAsync(int id);
        Task<Order> CreateAsync(Order order);
        Task<Order?> UpdateAsync(Order order, int id);
        Task<Order?> DeleteAsync(int id);
    }
}
