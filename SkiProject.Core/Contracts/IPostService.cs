using SkiProject.Core.Models;
using SkiProject.Infrastructure.Data.Models;
using SkiProject.Infrastructure.Data.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiProject.Core.Contracts
{
    public interface IPostService
    {
        /// <summary>
        /// Returns  all forum topics
        /// </summary>
        /// <returns></returns>
        Task<List<Post>> GetAllPosts(int topicId);

        /// <summary>
        /// Returns all posts in a topic by topic name
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        Task<List<ForumTopic>> GetAllTopics();

        

        /// <summary>
        /// Creates new post
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<Post> CreateNewPost(PostViewModel model);

        /// <summary>
        /// Gets topic by topic title
        /// </summary>
        /// <param name="topicTitle"></param>
        /// <returns></returns>
        Task<ForumTopic> GetCurrentTopic(string topicTitle);

        /// <summary>
        /// Add new post to the database
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        Task AddNewPost(Post post);

        /// <summary>
        /// Adds new topic to the database
        /// </summary>
        /// <param name="topic"></param>
        /// <returns></returns>
        Task<ForumTopic> CreateTopic(NewTopicViewModel model);
        Task AddNewTopic(ForumTopic topic);

        /// <summary>
        /// Returns a collection of the topics which the user can delete.The user can delete topics where were created by him only.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>

        Task<List<ForumTopic>> GetTopicsToDelete(string userId);

        /// <summary>
        /// Deletes topic
        /// </summary>
        /// <param name="topic"></param>
        /// <returns></returns>
        Task<List<ForumTopic>> DeleteCurrentTopic(ForumTopic topic);

        /// <summary>
        /// Gets current topic by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ForumTopic> GetCurrentTopicById(int id);

    }
}
