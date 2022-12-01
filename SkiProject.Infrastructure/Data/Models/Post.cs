using SkiProject.Infrastructure.Data.Models.Account;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SkiProject.Infrastructure.Validations.DataConstants.Post;

namespace SkiProject.Infrastructure.Data.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public ApplicationUser? User { get; set; }


        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int TopicId { get; set; }
        [ForeignKey(nameof(TopicId))]
        public ForumTopic Topic { get; set; }

        [Required]
        [MaxLength(ContentMaxLength, ErrorMessage = "Single post cannot be more than 3500 characters.")]
        public string Content { get; set; } = null!;
    }
}
