using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventManagementSystem.Data;
using EventManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace EventManagementSystem.Services.Implementation
{
    public class TicketService : ITicketService
    {
        private readonly ApplicationDbContext _context;

        public TicketService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Ticket> GetTicketByIdAsync(int ticketId)
        {
            return await _context.Tickets.FindAsync(ticketId);
        }

        public async Task<List<Ticket>> GetTicketsByEventIdAsync(int eventId) // Implement this method
        {
            return await _context.Tickets.Where(t => t.EventId == eventId).ToListAsync();
        }

        public Task<bool> SetTicketPriceAsync(int ticketId, decimal price)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateTicketAsync(Ticket ticket)
        {
            _context.Tickets.Update(ticket);
            return await _context.SaveChangesAsync() > 0;
        }

        // Implement other methods as needed
    }
}
