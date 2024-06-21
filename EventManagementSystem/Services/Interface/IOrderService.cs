using System.Threading.Tasks;
using EventManagementSystem.Models;

namespace EventManagementSystem.Services.Interfaces
{
    public interface IOrderService
    {
        Task<bool> ProcessRefundAsync(int id);
        Task RefundOrderAsync(int orderId);
        Task DeleteOrderAsync(int id);
        Task UpdateOrderAsync(Order updatedOrder);

            Task<Order> CreateOrderAsync(Order order);
        Task<Order> GetOrderByIdAsync(int id);
    }
}
