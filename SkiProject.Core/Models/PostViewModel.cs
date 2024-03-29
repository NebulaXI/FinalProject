﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkiProject.Infrastructure.Data.Models.Account;
using SkiProject.Infrastructure.Data.Models;
using static SkiProject.Infrastructure.Validations.DataConstants.Post;

namespace SkiProject.Core.Models
{
    public class PostViewModel
    {
        //[Key]
        //public int Id { get; set; }

        public string? UserId { get; set; } 

        [ForeignKey(nameof(UserId))]
        public ApplicationUser? User { get; set; }

        public string? Username { get; set; }

        public DateTime Date { get; set; }

        public int? TopicId { get; set; } 
        [ForeignKey(nameof(TopicId))]
        public ForumTopic? Topic { get; set; } 

        [Required]
        [MaxLength(ContentMaxLength, ErrorMessage = "Single post cannot be more than 3500 characters.")]
        public string? Content { get; set; } = null!;

        public IEnumerable<Post>? Posts { get; set; } 
        public string? CurrentTopic { get; set; }
    }
}

