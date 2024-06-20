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

        public async Task<bool> CreateTicketAsync(TicketDto ticketDto)
        {
            var ticket = new Ticket
            {
                EventId = ticketDto.EventId,
                UserId = ticketDto.UserId,
                Price = ticketDto.Price,
                TicketType = ticketDto.TicketType,
                IsSold = false
            };

            _context.Tickets.Add(ticket);
            await _context.SaveChangesAsync();
            return true;
        }

        public Task CreateTicketAsync(Ticket ticket)
        {
            throw new NotImplementedException();
        }

        public Task<Ticket> GetTicketByIdAsync(int ticketId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Ticket>> GetTicketsByEventIdAsync(int eventId)
        {
            return await _context.Tickets
                .Where(t => t.EventId == eventId && !t.IsSold)
                .ToListAsync();
        }

        public Task<bool> SetTicketPriceAsync(int ticketId, decimal price)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateTicketAsync(Ticket ticket)
        {
            throw new NotImplementedException();
        }

        Task<List<Ticket>> ITicketService.GetTicketsByEventIdAsync(int eventId)
        {
            throw new NotImplementedException();
        }

        // Other ticket service methods...
    }
}
