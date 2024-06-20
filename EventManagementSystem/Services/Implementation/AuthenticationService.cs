using EventManagementSystem.Data;
using EventManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EventManagementSystem.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly ApplicationDbContext _context; private readonly IConfiguration _configuration; private readonly ILogger<AuthenticationService> _logger;

        public AuthenticationService(ApplicationDbContext context, IConfiguration configuration, ILogger<AuthenticationService> logger)
        {
            _context = context; _configuration = configuration; _logger = logger;
        }

        public async Task<string> Register(UserDto userDto)
        {
            try
            {
                var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == userDto.Email);
                if (existingUser != null)
                    throw new Exception("User already exists");

                var user = new User
                {
                    UserName = userDto.Username,
                    Email = userDto.Email,
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword(userDto.Password),
                    Role = Roles.User,
                    FirstName = userDto.FirstName,
                    LastName = userDto.LastName,
                    Phone = userDto.Phone,
                    Address = userDto.Address,
                    City = userDto.City,
                    State = userDto.State,
                    ZipCode = userDto.ZipCode,
                    Country = userDto.Country
                };

                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                return GenerateJwtToken(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during registration for user {Email}", userDto.Email);
                throw;
            }
        }

        public async Task<string> Login(LoginDto loginDto)
        {
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == loginDto.Email);
                if (user == null || !BCrypt.Net.BCrypt.Verify(loginDto.Password, user.PasswordHash)) throw new Exception("Invalid credentials");

                return GenerateJwtToken(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during login for user {Email}", loginDto.Email);
                throw;
            }
        }

        private string GenerateJwtToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(issuer: _configuration["Jwt:Issuer"], audience: _configuration["Jwt:Issuer"], claims: claims, expires: DateTime.Now.AddMinutes(30), signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
