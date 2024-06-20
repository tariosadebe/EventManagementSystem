using EventManagementSystem.Models;
using EventManagementSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Stripe.Climate;
using System.Linq;
using System.Threading.Tasks;
using Order = EventManagementSystem.Models.Order;

namespace EventManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderRequest request)
        {
            var order = new Order
            {
                EventId = request.EventId,
                AttendeeId = request.AttendeeId,
                TotalAmount = request.Tickets.Sum(t => t.Price),
                Status = OrderStatus.Pending,
                Tickets = request.Tickets.Select(t => new Ticket
                {
                    EventId = request.EventId,
                    Price = t.Price,
                    TicketType = t.TicketType,
                    UserId = request.AttendeeId
                }).ToList()
            };

            var createdOrder = await _orderService.CreateOrderAsync(order);

            return Ok(createdOrder);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrder(int id)
        {
            var order = await _orderService.GetOrderByIdAsync(id);

            if (order == null)
            {
                return NotFound("Order not found.");
            }

            var orderDto = new OrderDto
            {
                Id = order.Id,
                EventId = order.EventId,
                AttendeeId = order.AttendeeId,
                TotalAmount = order.TotalAmount,
                Status = order.Status,
                Tickets = order.Tickets.Select(t => new TicketDto
                {
                    Id = t.Id,
                    Price = t.Price,
                    TicketType = t.TicketType,
                    EventId = t.EventId,
                    UserId = t.UserId
                }).ToList()
            };

            return Ok(orderDto);
        }

        [HttpPost("refund/{id}")]
        public async Task<IActionResult> ProcessRefund(int id)
        {
            var success = await _orderService.ProcessRefundAsync(id);

            if (!success)
            {
                return BadRequest("Refund failed.");
            }

            return Ok("Refund processed successfully.");
        }
    }
}
