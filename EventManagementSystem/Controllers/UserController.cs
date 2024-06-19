using System;
using System.Threading.Tasks;
using EventManagementSystem.Dtos;
using EventManagementSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost("register-admin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] AdminRegistrationDto adminRegistrationDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _userService.RegisterAdminAsync(adminRegistrationDto.User, adminRegistrationDto.PaymentAmount,
                    adminRegistrationDto.CertificationDocuments);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // Other user controller methods...
    }
}
