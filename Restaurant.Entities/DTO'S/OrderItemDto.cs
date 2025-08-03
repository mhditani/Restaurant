using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Entities.DTO_S
{
    public class OrderItemDto
    {
        public int Id { get; set; }
        public int MenuItemId { get; set; }
        public string MenuItemName { get; set; }  // Optional
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
