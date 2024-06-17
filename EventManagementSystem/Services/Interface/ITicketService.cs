using System.Collections.Generic;
using System.Threading.Tasks;
using EventManagementSystem.Models;

namespace EventManagementSystem.Services
{
    public interface ITicketService
    {
        Task<Ticket> GetTicketByIdAsync(int ticketId);
        Task<List<Ticket>> GetTicketsByEventIdAsync(int eventId); // Add this method
        Task<bool> SetTicketPriceAsync(int ticketId, decimal price);
        Task<bool> UpdateTicketAsync(Ticket ticket);
    }
}
