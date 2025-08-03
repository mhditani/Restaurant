using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Entities.DTO_S
{
    public class CreateOrderItemDto
    {
        [Required]
        public int MenuItemId { get; set; }
        [Required, Range(1, 100, ErrorMessage = "Quantity must be between 1 and 100")]
        public int Quantity { get; set; }

        // Optional: allow frontend to send price, or calculate it server-side
        [Required, Range(0.01, 1000, ErrorMessage = "Unit price must be between 0.01 and 1000")]
        public decimal UnitPrice { get; set; }
    }
}
