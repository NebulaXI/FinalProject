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
        Task<List<Post>> GetAllPosts(string title);
        Task<List<ForumTopic>> GetAllTopics();
        Task<ApplicationUser> GetCurrentUser(string id);
        Task<Post> CreateNewPost(PostViewModel model);
        Task<ForumTopic> GetCurrentTopic(string topicTitle);
        Task AddNewPost(Post post);
        Task<ForumTopic> CreateTopic(NewTopicViewModel model);
        Task AddNewTopic(ForumTopic topic);
        Task<List<ForumTopic>> GetTopicsToDelete(string userId);
        Task<List<ForumTopic>> DeleteCurrentTopic(ForumTopic topic);
        Task<ForumTopic> GetCurrentTopicById(int id);

    }
}
