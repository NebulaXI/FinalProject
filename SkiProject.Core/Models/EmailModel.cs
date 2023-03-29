using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using SendGrid.Helpers.Mail;
using SendGrid;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Web.Helpers;

namespace SkiProject.Core.Models
{
    public class EmailModel
    {
        [Required]
        public string From { get; set; }
        [Required]
        public string To { get; set; }
        [JsonProperty("subject")]
        public string Subject { get; set; }
        [JsonProperty("body")]
        public string Body { get; set; }
        public string Title { get; set; }
        [JsonProperty("imageUrl0")]
        public string ImageUrl0 { get; set; }
        [JsonProperty("head")]
        public string Head { get; set; }
        [JsonProperty("imageUrl1")]
        public string ImageUrl1 { get; set; }
        [JsonProperty("bodyHead")]
        public string BodyHead { get; set; }
        [JsonProperty("buttonText")]
        public string ButtonText { get; set; }
        [JsonProperty("buttonLink")]
        public string ButtonLink { get; set; }
        [JsonProperty("imageUrl2")]
        public string ImageUrl2 { get; set; }
    }
  
}
