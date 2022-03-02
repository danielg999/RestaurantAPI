using System;
using System.ComponentModel.DataAnnotations;

namespace RestaurantAPI.Models
{
    public class RegisterUserDto
    {
        [Required]
        public string Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Nationality { get; set; }
        [Required]
        [MinLength(7)]
        public string Password { get; set; }
        public int RoleId { get; set; } = 1;
    }
}
