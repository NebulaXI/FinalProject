using SkiProject.Infrastructure.Validations;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static SkiProject.Infrastructure.Validations.DataConstants.ApplicationUser;
using SkiProject.Infrastructure.Data.Models.Account;
using SkiProject.Infrastructure.Data.Models.Shop;

namespace SkiProject.Infrastructure.Data.Models.Account
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser() : base()
        {

        }

        [Required]
        [MaxLength(UserMaxFirstName, ErrorMessage = "First name cannot be more than 40 characters.")]
        public string? FirstName { get; set; } 


        [Required]
        [MaxLength(UserMaxLastName, ErrorMessage = "Last name cannot be more than 45 characters.")]
        public string? LastName { get; set; }

        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? Birthday { get; set; }

        [Required]
        [MaxLength(UsernameMax,ErrorMessage ="Username cannot be more than 30 characters.")]

        public override string? UserName { get; set; } 
        [Required]
        [EmailAddress]
        public override string? Email { get; set; }


        public IEnumerable<Reservation>? Reservations { get; set; }
        public IEnumerable<Post>? Posts { get; set; }
        public IEnumerable<ForumTopic>? CreatedTopics { get; set; }
        public List<Product>? CreatedProducts { get; set; }
        public List<Advertisment>? CreatedAdvertisments { get; set; }
        public virtual List<Message>? Messages { get; set; }

    }
}
