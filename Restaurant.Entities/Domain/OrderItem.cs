using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Entities.Domain
{
    public class OrderItem
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public int MenuItemId { get; set; }

        public int Quantity { get; set; }
        [Precision(16, 2)]
        public decimal UnitPrice { get; set; }

        // Navigation
        public Order Order { get; set; }

        public MenuItem MenuItem { get; set; }
    }
}
