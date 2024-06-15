﻿// Services/AttendeeService.cs
using EventManagementSystem.Data;
using EventManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using QRCoder; // Add QRCoder for generating QR codes
using System.IO;
using System.Drawing;

namespace EventManagementSystem.Services
{
    public class AttendeeService : IAttendeeService
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<AttendeeService> _logger;

        public AttendeeService(ApplicationDbContext context, ILogger<AttendeeService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<bool> RegisterAttendee(int eventId, string userId)
        {
            try
            {
                // Check if the attendee is already registered for the event
                var existingAttendee = await _context.Attendees
                    .FirstOrDefaultAsync(a => a.EventId == eventId && a.UserId == userId);

                if (existingAttendee != null)
                {
                    _logger.LogWarning("Attendee with ID {UserId} is already registered for event ID {EventId}", userId, eventId);
                    return false;
                }

                var ticketPurchase = PurchaseTicket(eventId, userId);

                // Generate a unique check-in code
                // var checkInCode = Guid.NewGuid().ToString();

                // Create a new attendee registration record
                var newAttendee = new Attendee
                {
                    EventId = eventId,
                    UserId = userId,
                    RegistrationTime = DateTime.UtcNow,
                    TicketPurchased = false, // Assuming ticket purchase is a separate step
                    CheckInTime = null, // Initialize check-in time as null (not checked in yet),
                    CheckInCode = "" // Set the generated check-in code
                };

                _context.Attendees.Add(newAttendee);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Attendee with ID {UserId} registered successfully for event ID {EventId}", userId, eventId);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error registering attendee for event ID {EventId}", eventId);
                throw;
            }
        }

        public async Task<bool> PurchaseTicket(int eventId, string userId)
        {
            try
            {
                var evnt = await _context.Events.FirstOrDefaultAsync(a => a.Id == eventId);
                if (evnt != null) 
                {
                    _logger.LogInformation("event not found");
                    return false;

                }

                //var request = new PaymentDto()
                //{
                //    Amount =
                //};

                //paymentService.ProcessPaymentAsync();


                // Find the attendee record for the user and event
                //var attendee = await _context.Attendees
                //    .FirstOrDefaultAsync(a => a.EventId == eventId && a.UserId == userId);

                //if (attendee == null)
                //{
                //    _logger.LogWarning("Attendee with ID {UserId} is not registered for event ID {EventId}. Cannot purchase ticket.", userId, eventId);
                //    return false;
                //}

                //// Update the ticket purchase status
                //attendee.TicketPurchased = true;

                //_context.Attendees.Update(attendee);
                //await _context.SaveChangesAsync();

                _logger.LogInformation("Attendee with ID {UserId} purchased ticket successfully for event ID {EventId}", userId, eventId);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error purchasing ticket for attendee with ID {UserId} for event ID {EventId}", userId, eventId);
                throw;
            }
        }

        public async Task<bool> CheckInAttendee(int eventId, string userId)
        {
            try
            {
                // Find the attendee record for the user and event
                var attendee = await _context.Attendees
                    .FirstOrDefaultAsync(a => a.EventId == eventId && a.UserId == userId);

                if (attendee == null)
                {
                    _logger.LogWarning("Attendee with ID {UserId} is not registered for event ID {EventId}. Cannot check-in.", userId, eventId);
                    return false;
                }

                // Check if the attendee has already checked in
                if (attendee.CheckInTime != null)
                {
                    _logger.LogWarning("Attendee with ID {UserId} has already checked in for event ID {EventId}.", userId, eventId);
                    return false;
                }

                // Update the check-in time
                attendee.CheckInTime = DateTime.UtcNow;

                _context.Attendees.Update(attendee);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Attendee with ID {UserId} checked in successfully for event ID {EventId}", userId, eventId);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error checking in attendee with ID {UserId} for event ID {EventId}", userId, eventId);
                throw;
            }
        }

        // Generate QR code for check-in
        public string GenerateQrCode(string checkInCode)
        {
            using (var qrGenerator = new QRCodeGenerator())
            {
                var qrCodeData = qrGenerator.CreateQrCode(checkInCode, QRCodeGenerator.ECCLevel.Q);
                var qrCode = new Base64QRCode(qrCodeData);
                return qrCode.GetGraphic(20); // Return base64 string of the QR code
            }
        }
    }
}
