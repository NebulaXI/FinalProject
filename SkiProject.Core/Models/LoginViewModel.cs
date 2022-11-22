using System.ComponentModel.DataAnnotations;

namespace SkiProject.Core.Models
{
    public class LoginViewModel
    {
        [Required]
        public string Username { get; set; } = null!;
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [UIHint("hidden")]
        public string? ReturnUrl { get; set; }
    }
}
