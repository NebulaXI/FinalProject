using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkiProject.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiProject.Infrastructure.Configuration
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        private List<Post> CreatePost()
        {
            var posts = new List<Post>();
            var p1 = new Post()
            {
                Id = 1,
                TopicId = 1,
                UserId = "d33b5866-1720-4e84-bfba-977e3a864f86",
                Date = DateTime.Now,
                Content = "1 topic,1 comment"
            };
            posts.Add(p1);
            var p2 = new Post()
            {
                Id = 2,
                TopicId = 1,
                UserId = "d33b5866-1720-4e84-bfba-977e3a864f86",
                Date = DateTime.Now,
                Content = "1 topic,2 comment"
            };
            posts.Add(p2);
            var p3 = new Post()
            {
                Id = 3,
                TopicId = 2,
                UserId = "d33b5866-1720-4e84-bfba-977e3a864f86",
                Date = DateTime.Now,
                Content = "2 topic,1 comment"
            };
            posts.Add(p3);

            return posts;
        }

        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasData(CreatePost());
        }
    }
}
