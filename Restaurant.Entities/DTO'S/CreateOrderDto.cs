using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Entities.DTO_S
{
    public class CreateOrderDto
    {
        public List<CreateOrderItemDto> OrderItems { get; set; }
    }
}
