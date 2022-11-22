using SkiProject.Infrastructure.Validations;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using static SkiProject.Infrastructure.Validations.DataConstants.ApplicationUser;

namespace SkiProject.Core.Models
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        [StringLength(UsernameMax,MinimumLength =2,ErrorMessage ="The username must be between 2 and 40 characters.")]
        public string Username { get; set; }

        [Required]
        [Compare(nameof(PasswordConfirmed))]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        public string PasswordConfirmed { get; set; } = null!;

        [Required]
        [StringLength(UserMaxFirstName, MinimumLength = 2, ErrorMessage = "Firstname must be between 2 an 40 characters.")]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(UserMaxLastName, MinimumLength = 2, ErrorMessage = "Lastname must be between 2 an 45 characters.")]
        public string LastName { get; set; } = null!;

        [Required]
        public DateTime Birthdate { get; set; }
    }
}
