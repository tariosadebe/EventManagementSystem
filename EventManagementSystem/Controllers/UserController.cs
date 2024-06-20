using EventManagementSystem.Models;
using EventManagementSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EventManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegistrationDto userDto)
        {
            var user = new User
            {
                UserName = userDto.Username,
                PasswordHash = HashPassword(userDto.Password),
                Email = userDto.Email,
                Phone = userDto.Phone,
                Role = userDto.Role
            };

            var result = await _userService.RegisterUserAsync(user);

            if (!result)
            {
                return BadRequest("User registration failed.");
            }

            return Ok("User registered successfully.");
        }

        private string HashPassword(string password)
        {
            // Implement password hashing logic here
            return password; // For demonstration purposes only
        }
    }
}
