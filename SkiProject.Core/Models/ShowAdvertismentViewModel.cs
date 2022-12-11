using SkiProject.Core.Services;
using SkiProject.Infrastructure.Data.Models.Account;
using SkiProject.Infrastructure.Data.Models.Shop;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SkiProject.Infrastructure.Validations.DataConstants.Advertisment;
using static SkiProject.Infrastructure.Validations.DataConstants.Product;

namespace SkiProject.Core.Models
{
    public class ShowAdvertismentViewModel
    {
            public int CategoryId {get; set;}
            public Category? Category {get; set;}
            public int GenderId {get;set;}
            public Gender? Gender {get;set;}
            public decimal Price {get;set; }
            [Required]
            [MaxLength(DescriptionMaxLength, ErrorMessage = "Description cannot be more than 3500 characters.")]
            public string? Description {get;set;}
            public IEnumerable<byte[]>? ImagesData { get; set; }
            public string? CreatedByUserId {get; set;}
            [Required]
            [MaxLength(AdvertismentTitleMaxLength, ErrorMessage = "Title cannot be more than 100 characters.")]
            public string? Title { get; set; }
            public ApplicationUser? User { get; set; }
            public DateTime CreatedOn {get; set;}
            public DateTime LastUpdatedOn {get; set;}
            [Required]    
            public List<Image>? Images { get; set; }

    }
}
