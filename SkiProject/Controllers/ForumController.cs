using Ganss.Xss;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkiProject.Core.Contracts;
using SkiProject.Core.Models;
using SkiProject.Infrastructure.Data.Models;
using System.Reflection.Metadata;
using System.Security.Claims;

namespace SkiProject.Controllers
{
    public class ForumController : BaseController
    {
        private readonly IPostService postService;
        public ForumController(IPostService _postService)
        {
            this.postService = _postService;
        }

       
        public async Task<IActionResult> Index()
        {
           var topics= await postService.GetAllTopics();
            if (topics.Count==0)
            {
                return View("NoTopics");
            }
           TopicViewModel model = new TopicViewModel() { Topics=topics};
           return View(model);
        }

        public async Task<IActionResult> GetTopicsToDelete()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var topicsEnabledToDelete=await postService.GetTopicsToDelete(userId);
            TopicViewModel model = new TopicViewModel { Topics=topicsEnabledToDelete};
            return View(model);
        }

        public async Task<IActionResult> DeleteCurrentTopic(int id)
        {

            var currentTopic = await postService.GetCurrentTopicById(id);
            await postService.DeleteCurrentTopic(currentTopic);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> GetAllPosts(string title)
        {
            if (title==null)
            {
                title = HttpContext.Request.Cookies["visited_topic"];
            }
            var topic = await postService.GetCurrentTopic(title);
            var posts = await postService.GetAllPosts(topic.Id);

            if (posts.Count>0)
            {
                posts.OrderByDescending(t => t.Date);
            }
            if (title!= HttpContext.Request.Cookies["visited_topic"])
            {
                HttpContext.Response.Cookies.Append("visited_topic", title);
            }
            foreach (var item in posts)
            {
                var userId = item.UserId;
                var user = await postService.GetCurrentUser(userId);
                item.Username = user.UserName;
            }
            PostViewModel model = new PostViewModel() { Posts=posts,CurrentTopic=title};
            return View(model);
        }

     
        [HttpPost]
        public async Task<IActionResult> AddPost(PostViewModel DTOmodel,string currentTopicTitle)
        {
            var sanitizer = new HtmlSanitizer();
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var topicTitle = currentTopicTitle;
            var topic = await postService.GetCurrentTopic(topicTitle);

            var model = new PostViewModel()
            {
                UserId =sanitizer.Sanitize( userId),
                User = await postService.GetCurrentUser(userId),
                Date = DateTime.Now,
                Topic = topic,
                TopicId = topic.Id,
                Content=sanitizer.Sanitize(DTOmodel.Content),
                CurrentTopic=topicTitle,
                Posts= await postService.GetAllPosts(topic.Id)
            };
           
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var post = await postService.CreateNewPost(model);
            await postService.AddNewPost(post);

            return RedirectToAction("GetAllPosts");
        }

        [HttpGet]
        public async Task<IActionResult> CreateNewTopic()
        {
            var model = new NewTopicViewModel();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> CreateNewTopic(NewTopicViewModel DTOModel)
        {
            var sanitizer = new HtmlSanitizer();
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var model = new NewTopicViewModel()
            {
                Title =sanitizer.Sanitize( DTOModel.Title),
                Content =sanitizer.Sanitize( DTOModel.Content),
                CreatedByUserId=userId,
                CreatedByUser= await postService.GetCurrentUser(userId),
                CreatedOn=DateTime.Now,
                LastUpdated=DateTime.Now,
                CommentsCount=1
            };

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var topic = await postService.CreateTopic(model);
            await postService.AddNewTopic(topic);
            return RedirectToAction("Index");
        }
    }
}
