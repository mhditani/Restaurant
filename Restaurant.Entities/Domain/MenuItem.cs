using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Entities.Domain
{
    public class MenuItem
    {
        public int Id { get; set; }

        public string Name { get; set; } = "";

        public string? Description { get; set; } 
        [Precision(16, 2)]

        public decimal Price { get; set; }

        public string Category { get; set; } = "";  // e.g., Main, Dessert, Drink

        public string? ImageUrl { get; set; }

        // Navigation
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
