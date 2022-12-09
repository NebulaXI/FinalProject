using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkiProject.Infrastructure.Data.Models.Shop;

using static SkiProject.Infrastructure.Validations.DataConstants.Advertisment;
using SkiProject.Infrastructure.Data.Models.Account;

namespace SkiProject.Core.Models
{
    public class NewAdvertismentViewModel
    {
        [Required]
        public int ProductId { get; set; }
        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }

        [Required]
        [MaxLength(AdvertismentTitleMaxLength, ErrorMessage = "Title cannot be more than 100 characters.")]
        public string Title { get; set; } = null!;

        [Required]
        public string UserId { get; set; } = null!;

        [ForeignKey(nameof(UserId))]
        public ApplicationUser? User { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime LastUpdatedOn { get; set; }
        public byte[]? Image { get; set; }
    }
}
