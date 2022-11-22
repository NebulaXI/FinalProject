using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static SkiProject.Infrastructure.Validations.DataConstants.UserBankCard;

namespace SkiProject.Core.Models
{
    public class BankCardViewModel
    {
        [Required]
        [RegularExpression(@"(\d{4}[- ]?){4}|\d{4}[- ]?\d{6}[- ]?\d{5}", ErrorMessage ="Credit card number must be in format:0000-0000-0000-0000")]
        public string CardNumber { get; set; } = null!;


        [Required]
        [RegularExpression(@"^(0[1-9]|1[0-2])$",ErrorMessage ="Please,pick up a valid month from 1 to 12.")]
        public string Month { get; set; } = null!;

        [Required]
        [RegularExpression(@"^20[0-9]{2}$", ErrorMessage = "Your credit card has expired!")]
        public string Year { get; set; } = null!;

        [Required]
        [RegularExpression(@"^\d{3}$",ErrorMessage ="Invalid CVV.Please check the back of your card for a three digit number.")]
        public string CVV { get; set; } = null!;

        [Required]
        [StringLength(MaxCardHolderName, MinimumLength = 3, ErrorMessage = "The name must be between 3 and 50 characters.")]
        public string CardHolderName { get; set; } = null!;

        [Required]
        [Precision(18,2)]
        public decimal Amount { get; set; }
    }
}
