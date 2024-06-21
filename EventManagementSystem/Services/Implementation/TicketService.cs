using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventManagementSystem.Data;
using EventManagementSystem.Models;
using EventManagementSystem.Services.Interfaces;
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

        public async Task<Ticket> GetTicketByIdAsync(int id)
        {
            return await _context.Tickets.FindAsync(id);
        }

        public async Task<IEnumerable<Ticket>> GetAllTicketsAsync()
        {
            return await _context.Tickets.ToListAsync();
        }

        public async Task CreateTicketAsync(Ticket newTicket)
        {
            _context.Tickets.Add(newTicket);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTicketAsync(Ticket updatedTicket)
        {
            _context.Tickets.Update(updatedTicket);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTicketAsync(int id)
        {
            var ticketToDelete = await _context.Tickets.FindAsync(id);
            if (ticketToDelete != null)
            {
                _context.Tickets.Remove(ticketToDelete);
                await _context.SaveChangesAsync();
            }

        }
    }
}
