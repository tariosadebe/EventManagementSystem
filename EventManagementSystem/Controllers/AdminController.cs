using EventManagementSystem.Models;
using EventManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EventManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpPost("create-admin")]
        public async Task<IActionResult> CreateAdmin([FromBody] AdminDto adminDto)
        {
            var result = await _adminService.CreateAdminAsync(adminDto);

            if (result)
            {
                return Ok("Admin account created successfully.");
            }
            else
            {
                return BadRequest("Failed to create admin account.");
            }
        }
    }
}
