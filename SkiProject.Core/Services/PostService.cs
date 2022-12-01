using Microsoft.EntityFrameworkCore;
using SkiProject.Core.Contracts;
using SkiProject.Core.Models;
using SkiProject.Infrastructure.Data.Common;
using SkiProject.Infrastructure.Data.Models;
using SkiProject.Infrastructure.Data.Models.Account;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;

namespace SkiProject.Core.Services
{
    public class PostService : IPostService
    {
        private readonly IRepository repo;
        public PostService(IRepository _repo)
        {
            this.repo = _repo;
        }

        public async Task<List<ForumTopic>> GetAllTopics()
        {
            var topics = await repo.All<ForumTopic>().ToListAsync();
            return topics;
        }

        public async Task<List<Post>> GetAllPosts(string title)
        {
            var posts = await repo.All<Post>().Where(o => o.Topic.Title == title).ToListAsync();


            return posts;
        }
        
        public async Task<ApplicationUser> GetCurrentUser(string id)
        {
            var user = repo.All<ApplicationUser>().FirstOrDefault(o => o.Id == id);
            return user;
        }
        
        public async Task AddNewPost(Post post)
        {
            var posts = await repo.All<Post>().ToListAsync();
            var topicTitle = post.Topic.Title;
            var topic = await GetCurrentTopic(topicTitle);
            posts.Add(post);
            topic.Posts.Add(post);
        }

        public async Task<ForumTopic> GetCurrentTopic(string topicTitle)
        {
            var topic = await repo.All<ForumTopic>().FirstOrDefaultAsync(o => o.Title == topicTitle);
            return topic;
        }

        public async Task<Post> CreateNewPost(PostViewModel model)
        {
            Post p1 = new Post()
            {
                UserId = model.UserId,
                User = model.User,
                Date = model.Date,
                Topic = model.Topic,
                TopicId = model.TopicId,
                Content = model.Content
            };
            return p1;
        }
    }
}
