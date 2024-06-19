using EventManagementSystem.Models;

namespace EventManagementSystem.Dtos
{
    public class AdminRegistrationDto
    {
        public User User { get; set; }
        public decimal PaymentAmount { get; set; }
        public string CertificationDocuments { get; set; }
    }
}
