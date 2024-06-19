using System.Collections.Generic;
using System.Threading.Tasks;
using EventManagementSystem.Models;

namespace EventManagementSystem.Services
{
    public interface ITicketService
    {
        Task CreateTicketAsync(Ticket ticket);
        Task<bool> SetTicketPriceAsync(int ticketId, decimal price);
        Task<Ticket> GetTicketByIdAsync(int ticketId);
        Task<List<Ticket>> GetTicketsByEventIdAsync(int eventId); // Add this method
        Task<bool> UpdateTicketAsync(Ticket ticket);
    }
}
