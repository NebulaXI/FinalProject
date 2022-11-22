using SkiProject.Infrastructure.Data.Models.Account;
using SkiProject.Infrastructure.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SkiProject.Infrastructure.Validations.DataConstants.UserBankCard;

namespace SkiProject.Infrastructure.Data.Models.Account
{
    public class UserBankCard
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [BankCardAttribute]
        public string CardNumber { get; set; } = null!;


        [Required]
        [RegularExpression(@"^(0[1-9]|1[0-2])$")]
        public string Month { get; set; } = null!;

        [Required]
        [RegularExpression(@"^20[0-9]{2}$")]
        public string Year { get; set; } = null!;

        [Required]
        [RegularExpression(@"^\d{3}$")]
        public string CVV { get; set; } = null!;

        [Required]
        [MaxLength(MaxCardHolderName, ErrorMessage = "Name cannot be more than 40 characters.")]
        public string CardHolderName { get; set; } = null!;

        [Required]
        public string UserId { get; set; } = null!;

        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; }
    }
}
