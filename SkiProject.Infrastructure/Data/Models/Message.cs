using SkiProject.Infrastructure.Data.Models.Account;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SkiProject.Infrastructure.Validations.DataConstants.Message;

namespace SkiProject.Infrastructure.Data.Models
{
    public class Message
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? SenderId { get; set; }
        //[ForeignKey(nameof(SenderId))]
        //public ApplicationUser? Sender { get; set; }

        [Required]
        public string? ReceiverId { get; set; }
        [ForeignKey(nameof(ReceiverId))]
        public ApplicationUser? Receiver { get; set; }


        [Required]
        [MaxLength(MessageMaxLength, ErrorMessage = "Single message cannot be more than 3500 characters.")]
        public string Content { get; set; } = null!;

        public DateTime? CreatedOn { get; set; }
    }
}
