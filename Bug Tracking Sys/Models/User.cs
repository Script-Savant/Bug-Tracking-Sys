using System.ComponentModel.DataAnnotations;

namespace Bug_Tracking_Sys.Models
{
    public enum UserRole
    {
        Admin,
        Developer,
        Tester
    }

    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "A name is required")]
        [StringLength(100, ErrorMessage = "Name cannot be longer than 100 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "An Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A role is required")]
        public UserRole Role { get; set; }

        [Required(ErrorMessage = "A password is required")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters long")]
        public string PasswordHash { get; set; }
    }
}