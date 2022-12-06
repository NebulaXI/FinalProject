using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiProject.Infrastructure.Data.Models.Shop
{
    public class Gender
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string NameOfGender { get; set; } = null!;
        public IEnumerable<Product>? Products { get; set; }
    }
}
