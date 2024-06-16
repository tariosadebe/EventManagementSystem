using EventManagementSystem.Data;
using EventManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace EventManagementSystem.Services.Implementation
{
    public class TicketService : ITicketService
    {
        private readonly ApplicationDbContext _context;

        public TicketService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> SetTicketPriceAsync(int ticketId, decimal price)
        {
            var ticket = await _context.Tickets.FindAsync(ticketId);

            if (ticket == null)
                return false;

            ticket.Price = price; // Assuming Ticket has a Price property
            _context.Tickets.Update(ticket);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<Ticket> GetTicketByIdAsync(int ticketId)
        {
            return await _context.Tickets.FindAsync(ticketId);
        }

        public async Task<bool> UpdateTicketAsync(Ticket ticket)
        {
            _context.Tickets.Update(ticket);
            await _context.SaveChangesAsync();
            return true;
        }

        Task ITicketService.UpdateTicketAsync(Ticket ticket)
        {
            throw new NotImplementedException();
        }
    }
}
