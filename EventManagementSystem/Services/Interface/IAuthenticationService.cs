using System.Threading.Tasks;
using EventManagementSystem.Models;

namespace EventManagementSystem.Services
{
    public interface IAuthenticationService
    {
        Task<string> Register(UserDto userDto);
        Task<string> Login(LoginDto loginDto);
    }
}
