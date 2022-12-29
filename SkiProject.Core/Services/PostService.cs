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
using System.Runtime.CompilerServices;

namespace SkiProject.Core.Services
{
    public class PostService : IPostService
    {
        private readonly IRepository repo;
        public PostService(IRepository _repo)
        {
            this.repo = _repo;
        }


        /// <summary>
        /// Returns  all forum topics
        /// </summary>
        /// <returns></returns>
        public async Task<List<ForumTopic>> GetAllTopics()
        {
            var topics = await repo.All<ForumTopic>().ToListAsync();
            return topics;
        }

        /// <summary>
        /// Returns all posts in a topic by topic name
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>

        public async Task<List<Post>> GetAllPosts(int topicId)
        {
            var posts = await repo.All<Post>().Where(o => o.TopicId == topicId).ToListAsync();


            return posts;
        }

        /// <summary>
        /// Gets user by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        
        public async Task<ApplicationUser> GetCurrentUser(string id)
        {
            var user = repo.All<ApplicationUser>().FirstOrDefault(o => o.Id == id);
            return user;
        }
        
        /// <summary>
        /// Adds new post to the database
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        public async Task AddNewPost(Post post)
        {
            var posts = await repo.All<Post>().ToListAsync();
            var topicTitle = post.Topic.Title;
            var topic = await GetCurrentTopic(topicTitle);
            posts.Add(post);
            topic.Posts.Add(post);
            topic.CommentsCount = topic.Posts.Count();
            topic.LastUpdated = DateTime.Now;
            await repo.SaveChangesAsync();
        }

        /// <summary>
        /// Adds new topic to the database
        /// </summary>
        /// <param name="topic"></param>
        /// <returns></returns>
        public async Task AddNewTopic(ForumTopic topic)
        {
            var topics = await repo.All<ForumTopic>().ToListAsync();
            var posts = await repo.All<Post>().ToListAsync();
            var postsOfCurrentTopic = topic.Posts;
            foreach (var post in postsOfCurrentTopic)
            {
                posts.Add(post);
            }
            await repo.AddAsync(topic);
            await repo.SaveChangesAsync();
        }


        /// <summary>
        /// Gets topic by topic title
        /// </summary>
        /// <param name="topicTitle"></param>
        /// <returns></returns>
        public async Task<ForumTopic> GetCurrentTopic(string topicTitle)
        {
            var topic = await repo.All<ForumTopic>().FirstOrDefaultAsync(o => o.Title == topicTitle);
            return topic;
        }

        /// <summary>
        /// Gets current topic by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ForumTopic> GetCurrentTopicById(int id)
        {
            return await repo.All<ForumTopic>().FirstOrDefaultAsync(o => o.Id == id);
        }

        /// <summary>
        /// Creates new post
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<Post> CreateNewPost(PostViewModel model)
        {
            Post p1 = new Post()
            {
                UserId = model.UserId,
                User = model.User,
                Date = model.Date,
                Topic = model.Topic,
                TopicId = model.TopicId ?? default(int),
                Content = model.Content,
                Username=model.Username
            };
            return p1;
        }


        /// <summary>
        /// Creates new topic
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<ForumTopic> CreateTopic(NewTopicViewModel model) 
        { 
           
            ForumTopic topic = new ForumTopic()
            {
                Title = model.Title,
                CreatedByUserId = model.CreatedByUserId,
                CreatedByUser = model.CreatedByUser,
                CreatedOn = model.CreatedOn,
                LastUpdated = model.LastUpdated,
                CommentsCount = model.CommentsCount,
                Posts=new List<Post>()

            };
            var post = new Post()
            {
                UserId = model.CreatedByUserId,
                User = model.CreatedByUser,
                Date = model.CreatedOn,
                Topic = topic,
                TopicId = topic.Id,
                Content = model.Content
            };
            topic.Posts.Add(post);
            return topic;
        }

        /// <summary>
        /// Returns a collection of the topics which the user can delete.The user can delete topics where were created by him only.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>

        public async Task<List<ForumTopic>> GetTopicsToDelete(string userId)
        {
            var topics = await GetAllTopics();
            var topicsEnableToDelete = new List<ForumTopic>(); foreach (var topic in topics)
            {
                if (topic.CreatedByUserId == userId)
                {
                    topicsEnableToDelete.Add(topic);
                }
            }
            return topicsEnableToDelete;
        }


        /// <summary>
        /// Deletes topic
        /// </summary>
        /// <param name="topic"></param>
        /// <returns></returns>
        public async Task<List<ForumTopic>> DeleteCurrentTopic(ForumTopic topic)
        {
            var topics = await GetAllTopics();
            var deleteTopic =  topics.Remove(topic);
            repo.Delete(topic);
            await repo.SaveChangesAsync();
            return topics;
        }

    }
}
