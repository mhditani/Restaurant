using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Entities.Domain;
using Restaurant.Entities.DTO_S;
using Restaurant.Services.IRepositories;

namespace RestaurantApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepo repo;
        private readonly IMapper mapper;

        public OrderController(IOrderRepo repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllOrders(
         [FromQuery] string? status,
         [FromQuery] DateTime? startDate,
         [FromQuery] DateTime? endDate,
         [FromQuery] string? sortBy,
         [FromQuery] bool? isAscending,
         [FromQuery] int pageNumber = 1,
         [FromQuery] int pageSize = 10)
        {
            var orders = await repo.GetAllAsync(status, startDate, endDate, sortBy, isAscending, pageNumber, pageSize);
            return Ok(mapper.Map<List<OrderDto>>(orders));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var orderDomain = await repo.GetByIdAsync(id);
            if (orderDomain == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<OrderDto>(orderDomain));
        }


        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderDto dto)
        {
            var orderDomain = mapper.Map<Order>(dto);

            orderDomain = await repo.CreateAsync(orderDomain);

            var orderDto = mapper.Map<OrderDto>(orderDomain);

            return CreatedAtAction(nameof(GetById), new {orderDomain.Id},  orderDto);
        }


        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateStatus([FromRoute] int id, [FromBody] UpdateOrderDto dto)
        {

            var orderDomain = mapper.Map<Order>(dto);
            orderDomain = await repo.UpdateAsync(orderDomain, id);
            if (orderDomain == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<OrderDto>(orderDomain));
        }


        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var existingOrder = await repo.DeleteAsync(id);
            if (existingOrder == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<OrderDto>(existingOrder));
        }
    }
}
