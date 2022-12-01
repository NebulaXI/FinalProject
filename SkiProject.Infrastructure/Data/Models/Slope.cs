using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiProject.Infrastructure.Data.Models
{
    public class Slope
    {
        [Key]
        public int Id { get; set; }

        public int CityId { get; set; }
        [ForeignKey(nameof(CityId))]
        public City? City { get; set; }

        [Required]
        [Precision(18,2)]
        public decimal PricePerDayChildren { get; set; }
        [Required]
        [Precision(18, 2)]
        public decimal PricePerDayAdult { get; set; }
        [Required]
        [Precision(18, 2)]
        public decimal PriceForSeasonChildren { get; set; }
        [Required]
        [Precision(18, 2)]
        public decimal PriceForSeasonAdult { get; set; }

    }
}
