using Microsoft.EntityFrameworkCore;
using SkiProject.Infrastructure.Data.Models.Account;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiProject.Infrastructure.Data.Models
{
    public class Reservation
    {
        [Key]
        public int Id { get; set; }


        [Required]
        public DateTime StartDate { get; set; }


        [Required]
        public DateTime EndDate { get; set; }


        [Required]
        public int NumberOfGuests { get; set; }


        [Required]
        public int PlaceToStayId { get; set; }
        [ForeignKey(nameof(PlaceToStayId))]
        public PlaceToStay PlaceToStay { get; set; }


        [Required]
        [Precision(18,2)]
        public decimal PriceOfTheReservation { get; set; }


        [Required]
        [Precision(18,2)]
        public decimal PrepaidOfTheReservation { get; set; }


        [Required]
        [Precision(18,2)]
        public decimal LeftToPay { get; set; }


        [Required]
        public string UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public ApplicationUser  User { get; set; }
    }
}
