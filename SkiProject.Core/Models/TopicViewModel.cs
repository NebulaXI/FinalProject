using SkiProject.Infrastructure.Data.Models;
using SkiProject.Infrastructure.Data.Models.Account;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using static SkiProject.Infrastructure.Validations.DataConstants.ForumTopic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiProject.Core.Models
{
    public class TopicViewModel
    {
        //    [Required]
        //    [StringLength(TitleMaxLength, MinimumLength = 2, ErrorMessage = "The title of the topic must be between 2 and 100 characters.")]
        //    public string Title { get; set; } = null!;
        //    public string? CreatedByUserId { get; set; }
        //    public DateTime CreatedOn { get; set; }
        //    public List<Post>?  Posts { get; set; }
        //

        public List<ForumTopic> Topics { get; set; }
        public List<Post> Posts { get; set; }
        public int CountOfComments { get; set; }
    }
}
