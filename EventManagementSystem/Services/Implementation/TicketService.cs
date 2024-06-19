using System;
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

        public async Task CreateTicketAsync(Ticket ticket)
        {
            if (ticket.Price < 100)
            {
                throw new Exception("Ticket price cannot be less than 100 Naira.");
            }

            _context.Tickets.Add(ticket);
            await _context.SaveChangesAsync();
        }

        public Task<Ticket> GetTicketByIdAsync(int ticketId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Ticket>> GetTicketsByEventIdAsync(int eventId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> SetTicketPriceAsync(int ticketId, decimal price)
        {
            if (price < 100)
            {
                throw new Exception("Ticket price cannot be less than 100 Naira.");
            }

            var ticket = await _context.Tickets.FindAsync(ticketId);
            if (ticket == null)
            {
                return false;
            }

            ticket.Price = price;
            await _context.SaveChangesAsync();

            return true;
        }

        public Task<bool> UpdateTicketAsync(Ticket ticket)
        {
            throw new NotImplementedException();
        }

        // Other ticket service methods...
    }
}
