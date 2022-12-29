using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SkiProject.Infrastructure.Validations.DataConstants.ForumTopic;
using SkiProject.Infrastructure.Data.Models;
using SkiProject.Infrastructure.Data.Models.Account;
using static SkiProject.Infrastructure.Validations.DataConstants.Post;
using Microsoft.EntityFrameworkCore;

namespace SkiProject.Core.Models
{
    public class NewTopicViewModel
    {

        [Required]
        [MaxLength(TitleMaxLength, ErrorMessage = "The title of the topic cannot be more than 100 characters.")]
        //[Index(IsUnique = true)]
        public string Title { get; set; } = null!;
        [Required]
        [MaxLength(ContentMaxLength, ErrorMessage = "Single post cannot be more than 3500 characters.")]
        public string? Content { get; set; } = null!;

        public List<Post>? Posts { get; set; } = new List<Post>();
        
        public string? CreatedByUserId { get; set; }=null!;
        [ForeignKey(nameof(CreatedByUserId))]
        
        public ApplicationUser? CreatedByUser { get; set; } = null!;

        [Required]
        public DateTime CreatedOn { get; set; } 
        [Required]
        public DateTime LastUpdated { get; set; }

        public int? CommentsCount { get; set; } = null!;
    }
}
