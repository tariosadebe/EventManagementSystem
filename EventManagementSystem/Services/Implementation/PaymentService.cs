using EventManagementSystem.Data;
using EventManagementSystem.Models;

namespace EventManagementSystem.Services.Implementation
{
    public class PaymentService : IPaymentService
    {
        private readonly ApplicationDbContext _context;
        private readonly ITicketService _ticketService;
        private readonly IEmailService _emailService;
        private readonly ILogger<PaymentService> _logger;

        public PaymentService(ApplicationDbContext context, ITicketService ticketService, IEmailService emailService, ILogger<PaymentService> logger)
        {
            _context = context;
            _ticketService = ticketService;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<PaymentResponseDto> ProcessPaymentAsync(PaymentDto paymentDto)
        {
            try
            {
                // Simulating payment processing logic
                var paymentSuccess = SimulatePaymentGatewayResponse(paymentDto);

                if (!paymentSuccess)
                {
                    _logger.LogWarning($"Payment failed for Ticket ID {paymentDto.TicketId}");
                    return new PaymentResponseDto
                    {
                        Success = false,
                        Message = "Payment processing failed."
                    };
                }

                // Update the ticket status to paid if payment is successful
                var ticket = await _ticketService.GetTicketByIdAsync(paymentDto.TicketId);
                if (ticket == null)
                {
                    _logger.LogWarning($"Ticket not found for ID {paymentDto.TicketId}");
                    return new PaymentResponseDto
                    {
                        Success = false,
                        Message = "Ticket not found."
                    };
                }

                ticket.IsPaid = true;
                ticket.Code = GenerateTicketCode();
                await _ticketService.UpdateTicketAsync(ticket);

                // Get the event to retrieve the admin/user information
                var eventDetails = await _context.Events.FindAsync(ticket.EventId);
                if (eventDetails == null)
                {
                    _logger.LogWarning($"Event not found for Ticket ID {paymentDto.TicketId}");
                    return new PaymentResponseDto
                    {
                        Success = false,
                        Message = "Event not found."
                    };
                }

                var admin = await _context.Users.FindAsync(eventDetails.AdminId);
                if (admin == null)
                {
                    _logger.LogWarning($"Admin not found for Event ID {eventDetails.Id}");
                    return new PaymentResponseDto
                    {
                        Success = false,
                        Message = "Admin not found."
                    };
                }

                // Send confirmation email with ticket code
                var emailSent = await _emailService.SendEmailAsync(admin.Email, "Ticket Confirmation", $"Your payment was successful. Your ticket code is {ticket.Code}.");
                if (!emailSent)
                {
                    _logger.LogWarning($"Failed to send confirmation email to {admin.Email}");
                    return new PaymentResponseDto
                    {
                        Success = true,
                        Message = "Payment processed, but failed to send confirmation email.",
                        TransactionId = GenerateTransactionId()
                    };
                }

                _logger.LogInformation($"Payment processed successfully for Ticket ID {paymentDto.TicketId}");

                return new PaymentResponseDto
                {
                    Success = true,
                    Message = "Payment processed successfully.",
                    TransactionId = GenerateTransactionId()
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error processing payment for Ticket ID {paymentDto.TicketId}");
                return new PaymentResponseDto
                {
                    Success = false,
                    Message = "An error occurred while processing the payment."
                };
            }
        }

        private bool SimulatePaymentGatewayResponse(PaymentDto paymentDto)
        {
            // Simulate a payment gateway response
            // In a real application, this would involve making an API call to a payment gateway

            // For simulation, let's assume payments with an amount greater than zero and a valid payment method are successful
            if (paymentDto.Amount > 0 && !string.IsNullOrEmpty(paymentDto.PaymentMethod))
            {
                // Simulate a random success rate
                Random rnd = new Random();
                return rnd.Next(100) < 90; // 90% success rate
            }

            return false;
        }

        private string GenerateTransactionId()
        {
            // Generate a simulated transaction ID
            return $"TXN{Guid.NewGuid().ToString("N").Substring(0, 10).ToUpper()}";
        }

        private string GenerateTicketCode()
        {
            // Generate a unique ticket code
            return $"TICKET{Guid.NewGuid().ToString("N").Substring(0, 8).ToUpper()}";
        }

        public Task<bool> ProcessPaymentAsync(decimal amount, string currency, string userId)
        {
            throw new NotImplementedException($"{nameof(ProcessPaymentAsync)}(decimal amount, string currency, string userId) is not implemented.");
        }
    }
}
