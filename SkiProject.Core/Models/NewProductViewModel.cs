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

        public IEnumerable<Image>? ProductImages { get; set; }
        public string CreatedByUserId { get; set; }
    }
}
