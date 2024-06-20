using System.Threading.Tasks;
using EventManagementSystem.Models;

namespace EventManagementSystem.Services.Interfaces
{
    public interface IOrderService
    {
        Task<Order> CreateOrderAsync(Order order);
        Task<Order> GetOrderByIdAsync(int id);
        Task<bool> ProcessRefundAsync(int id);
    }
}
