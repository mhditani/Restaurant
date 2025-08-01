using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Entities.Domain
{
    public class Order
    {
        public int Id { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.Now;
        [Precision(16, 2)]
        public decimal TotalAmount { get; set; }

        public string Status { get; set; } = ""; // Pending, Completed, Cancelled

        // Navigation


        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
