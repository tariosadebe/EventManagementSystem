﻿using System.ComponentModel.DataAnnotations;

namespace EventManagementSystem.Models
{
    public class UserDto
    {
        [Required(ErrorMessage = "Username is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Username must be between 3 and 50 characters")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters")]
        public string Password { get; set; }

        [Required(ErrorMessage = "First name is required")]
        [StringLength(50, ErrorMessage = "First name cannot exceed 50 characters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [StringLength(50, ErrorMessage = "Last name cannot exceed 50 characters")]
        public string LastName { get; set; }

        [StringLength(15, ErrorMessage = "Phone number cannot exceed 15 characters")]
        public string Phone { get; set; }

        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [StringLength(100, ErrorMessage = "Address cannot exceed 100 characters")]
        public string Address { get; set; }

        [StringLength(50, ErrorMessage = "City cannot exceed 50 characters")]
        public string City { get; set; }

        [StringLength(50, ErrorMessage = "State cannot exceed 50 characters")]
        public string State { get; set; }

        [StringLength(10, ErrorMessage = "Zip code cannot exceed 10 characters")]
        public string ZipCode { get; set; }

        [StringLength(50, ErrorMessage = "Country cannot exceed 50 characters")]
        public string Country { get; set; }
    }
}
