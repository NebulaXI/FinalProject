using Microsoft.EntityFrameworkCore;
using SkiProject.Infrastructure.Data.Models.Shop;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SkiProject.Infrastructure.Validations.DataConstants.Product;
using Microsoft.AspNetCore.Mvc;
using System.Web.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SelectListItem = Microsoft.AspNetCore.Mvc.Rendering.SelectListItem;
using static SkiProject.Infrastructure.Validations.DataConstants.Advertisment;
using SkiProject.Infrastructure.Data.Models.Account;

namespace SkiProject.Core.Models
{
    public class NewProductViewModel
    {

        [Required]
        public int CategoryId { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public Category? Category { get; set; }
        public List<SelectListItem>? Categories { get; set; } = null!;
        public string? SelectedCategory { get; set; }
        public string? SelectedCategoryText { get; set; }

        [Required]
        public int GenderId { get; set; }
        [ForeignKey(nameof(GenderId))]
        public Gender? Gender { get; set; }
        public List<SelectListItem>? Genders { get; set; } = null!;
        public string? SelectedGender { get; set; }
        public string? SelectedGenderText { get; set; }


        [Required]
        [Precision(18, 2)]
        public decimal Price { get; set; }


        [MaxLength(DescriptionMaxLength, ErrorMessage = "Description cannot be more than 3500 characters.")]
        public string? Description { get; set; }

        public IEnumerable<ProductImage>? ProductImages { get; set; }
        public string? CreatedByUserId { get; set; }



        [Required]
        [MaxLength(AdvertismentTitleMaxLength, ErrorMessage = "Title cannot be more than 100 characters.")]
        public string Title { get; set; } = null!;


        [ForeignKey(nameof(CreatedByUserId))]
        public ApplicationUser? User { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime LastUpdatedOn { get; set; }
    }
}
