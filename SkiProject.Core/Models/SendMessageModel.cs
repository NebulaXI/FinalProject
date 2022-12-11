using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkiProject.Infrastructure.Data.Models.Account;
using static SkiProject.Infrastructure.Validations.DataConstants.Message;

namespace SkiProject.Core.Models
{
    public class SendMessageModel
    {
        public string? SenderId { get; set; }
        public ApplicationUser? Sender { get; set; }

        
        public string? ReceiverId { get; set; }
        public ApplicationUser? Receiver { get; set; }
        public string? ReceiverName { get; set; }


        [Required]
        [MaxLength(MessageMaxLength, ErrorMessage = "Single message cannot be more than 3500 characters.")]
        public string Content { get; set; } = null!;
    }
}
