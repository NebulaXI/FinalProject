using SkiProject.Core.Services;
using SkiProject.Infrastructure.Data.Models.Account;
using SkiProject.Infrastructure.Data.Models.Shop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiProject.Core.Models
{
    public class ShowAdvertismentViewModel
    {
            public int CategoryId {get; set;}
            public Category? Category {get; set;}
            public int GenderId {get;set;}
            public Gender Gender {get;set;}
            public decimal Price {get;set; }
            public string? Description {get;set;}
            public IEnumerable<Image>?ProductImages {get; set;}
            public string? CreatedByUserId {get; set;}
            public string? Title { get; set; }
            public ApplicationUser? User { get; set; }
            public DateTime CreatedOn {get; set;}
            public DateTime LastUpdatedOn {get; set;}
        
    }
}
