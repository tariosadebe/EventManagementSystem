using System.Threading.Tasks;

namespace EventManagementSystem.Services
{
    public interface IEmailService
    {
        Task<bool> SendEmailAsync(string to, string subject, string body);
    }
}
