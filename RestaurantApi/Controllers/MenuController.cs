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
    public class MenuController : ControllerBase
    {
        private readonly IMenuRepo repo;
        private readonly IMapper mapper;

        public MenuController(IMenuRepo repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }

        [HttpGet("GetAllMenu")]
        public async Task<IActionResult> GetAllMenu()
        {
            var menuItemDomain = await repo.GetAllAsync();
            return Ok(mapper.Map<List<MenuItemDto>>(menuItemDomain));
        }


        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var menuItemDomain = await repo.GetByIdAsync(id);
            if (menuItemDomain == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<MenuItemDto>(menuItemDomain));
        }


        [HttpPost("CreateMenu")]
        public async Task<IActionResult> CreateMenu(CreateMenuItemDto createMenuItemDto)
        {
            var menuItemDomain =  mapper.Map<MenuItem>(createMenuItemDto);

            menuItemDomain = await repo.CreateAsync(menuItemDomain);

            var menuItemDto = mapper.Map<MenuItemDto>(menuItemDomain);

            return CreatedAtAction(nameof(GetById), new { menuItemDomain.Id }, menuItemDto);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateMenu([FromRoute] int id, [FromBody] UpdateMenuItemDto updateMenuItemDto)
        {
            var menuItemDomain = mapper.Map<MenuItem>(updateMenuItemDto);

            var updatedMenu = await repo.UpdateAsync(menuItemDomain, id);

            if (updatedMenu == null)
            {
                return NotFound();
            }

            var menuItemDto = mapper.Map<MenuItemDto>(updatedMenu);
            return Ok(menuItemDto);
        }


        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteMenu([FromRoute] int id)
        {
            var existingMenu = await repo.DeleteAsync(id);
            if (existingMenu == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<MenuItemDto>(existingMenu));
        }
    }
}
