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
    public class PlaceToStay
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public int CityId { get; set; }

        [ForeignKey(nameof(CityId))]
        public City City { get; set; }
        [Required]
        public int Capacity { get; set; }
        [Required]
        [Precision(18,2)]
        public decimal PricePerNightForAPerson { get; set; }

        public IEnumerable<Reservation> Reservations { get; set; } = new List<Reservation>();

    }
}
