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
    internal class ForumTopicsConfiguration : IEntityTypeConfiguration<ForumTopic>
    {
        private List<ForumTopic> CreateTopics()
        {
            var topics = new List<ForumTopic>();

            var firstTopic = new ForumTopic()
            {
                Id = 1,
                Title = "First topic",
                CreatedOn = DateTime.Now,
                LastUpdated = DateTime.Now,
                CreatedByUserId= "d33b5866-1720-4e84-bfba-977e3a864f86",
                CommentsCount= 3,
            };
            topics.Add(firstTopic);
            var secondTopic = new ForumTopic()
            {
                Id = 2,
                Title = "Second topic",
                CreatedOn = DateTime.Now,
                LastUpdated = DateTime.Now,
                CreatedByUserId = "d33b5866-1720-4e84-bfba-977e3a864f86",
                CommentsCount=1
            };
            topics.Add(secondTopic);

            return topics;
        }
        public void Configure(EntityTypeBuilder<ForumTopic> builder)
        {
            builder.HasData(CreateTopics());
        }
    }
}
