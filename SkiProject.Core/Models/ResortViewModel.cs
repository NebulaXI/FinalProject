using SkiProject.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiProject.Core.Models
{
    public class ResortViewModel
    {
        public string? Name { get; set; }
        public List<PlaceToStay>?  PlacesToStay { get; set; }
        public Slope? Slope { get; set; }

    }
}
