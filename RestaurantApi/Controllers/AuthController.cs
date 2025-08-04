using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Entities.DTO_S;
using Restaurant.Services.IRepositories;

namespace RestaurantApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly ITokenRepo tokenRepo;

        public AuthController(UserManager<IdentityUser> userManager, ITokenRepo tokenRepo)
        {
            this.userManager = userManager;
            this.tokenRepo = tokenRepo;
        }


        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto registerRequestDto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // user manager class that identity provide us
            var identityUser = new IdentityUser
            {
                UserName = registerRequestDto.Username,
                Email = registerRequestDto.Username
            };

            var identityResult = await userManager.CreateAsync(identityUser, registerRequestDto.Password);

            if (identityResult.Succeeded)
            {
                // Add Roles to this User
                if (registerRequestDto.Roles != null && registerRequestDto.Roles.Any())
                {
                    identityResult = await userManager.AddToRolesAsync(identityUser, registerRequestDto.Roles);
                    if (identityResult.Succeeded)
                    {
                        return Ok("User was registered. Please login.");
                    }
                }
            }

            return BadRequest(identityResult.Errors);
        }


        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody]LoginRequestDto loginRequestDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await userManager.FindByEmailAsync(loginRequestDto.Username);

            if (user == null)
                return Unauthorized("Invalid credentials.");

            var checkPassword = await userManager.CheckPasswordAsync(user, loginRequestDto.Password);

            if (!checkPassword)
                return Unauthorized("Invalid credentials.");

            var roles = await userManager.GetRolesAsync(user);
            var token = tokenRepo.createJwToken(user, roles.ToList());

            return Ok(new LoginResponseDto { Jwtoken = token });
        }
    }
}
