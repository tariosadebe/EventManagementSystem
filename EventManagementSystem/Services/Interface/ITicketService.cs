using EventManagementSystem.Models;
using System.Threading.Tasks;

namespace EventManagementSystem.Services
{
    public interface ITicketService
    {
        Task<Ticket> GetTicketByIdAsync(int ticketId);
        Task<bool> SetTicketPriceAsync(int ticketId, decimal price);
        Task UpdateTicketAsync(Ticket ticket);
    }
}
