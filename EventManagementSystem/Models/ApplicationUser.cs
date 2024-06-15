using Microsoft.AspNetCore.Identity;

namespace EventManagementSystem.Models
{
    public class ApplicationUser : IdentityUser
    {
        // Your custom properties
        public string Country { get; set; }
        public string ZipCode { get; internal set; }
        public string State { get; internal set; }
        public string City { get; internal set; }
        public string Address { get; internal set; }
        public string Phone { get; internal set; }
        public string Name { get; internal set; }
    }
}
