using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiProject.Infrastructure.Data.Models.Shop
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string NameOfCategory { get; set; }

        public IEnumerable<Product>? Products { get; set; }
    }
}
