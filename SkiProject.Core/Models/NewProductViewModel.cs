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

namespace SkiProject.Core.Models
{
    public class NewProductViewModel
    {

        [Required]
        public int CategoryId { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public Category? Category { get; set; }


        [Required]
        public int GenderId { get; set; }
        [ForeignKey(nameof(GenderId))]
        public Gender? Gender { get; set; }


        [Required]
        [Precision(18, 2)]
        public decimal Price { get; set; }


        [MaxLength(DescriptionMaxLength, ErrorMessage = "Description cannot be more than 3500 characters.")]
        public string? Description { get; set; }

        public IEnumerable<Image>? ProductImages { get; set; }
    }
}
