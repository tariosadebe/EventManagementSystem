using EventManagementSystem.Data;
using EventManagementSystem.Models;
using EventManagementSystem.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EventManagementSystem.Services.Implementation
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _context;

        public OrderService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Order> CreateOrderAsync(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<Order> GetOrderByIdAsync(int id)
        {
            return await _context.Orders.Include(o => o.Tickets)
                                        .FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<bool> ProcessRefundAsync(int id)
        {
            var order = await _context.Orders.FindAsync(id);

            if (order == null)
            {
                return false;
            }

            order.Status = OrderStatus.Refunded;
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
