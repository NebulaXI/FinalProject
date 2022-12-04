using Microsoft.EntityFrameworkCore;
using SkiProject.Infrastructure.Data.Models.Account;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SkiProject.Infrastructure.Validations.DataConstants.ForumTopic;

namespace SkiProject.Infrastructure.Data.Models
{
    public class ForumTopic
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(TitleMaxLength, ErrorMessage = "The title of the topic cannot be more than 100 characters.")]
        public string Title { get; set; } = null!;
        public List<Post>? Posts { get; set; }
        [Required]
        public string? CreatedByUserId { get; set; }
        [ForeignKey(nameof(CreatedByUserId))]
        public ApplicationUser? CreatedByUser { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }
        [Required]
        public DateTime LastUpdated { get; set; }

        [Required]
        public int? CommentsCount { get; set; }
    }
}
