﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiProject.Core.Models
{
    public class LocationViewModel
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public double Latitude { get; set; }
        public double Longitude { get; set; }
       
    }

    //public class LocationLists
    //{
    //    public IEnumerable<LocationViewModel> LocationList { get; set; }=new List<LocationViewModel>();
    //}
}

