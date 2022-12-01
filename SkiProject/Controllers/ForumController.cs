using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkiProject.Core.Contracts;
using SkiProject.Core.Models;
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
            //foreach (var item in topics)
            //{
            //    HttpContext.Response.Cookies.Append("visited_topic", item.Title);
            //}
            PostViewModel model = new PostViewModel() { Topics=topics};
            return View(model);
        }

        public async Task<IActionResult> GetAllPosts(string title)
        {
            var posts = await postService.GetAllPosts(title);
            if (posts.Count>0)
            {
                posts.OrderByDescending(t => t.Date);
            }

            HttpContext.Response.Cookies.Append("visited_topic", title);
            PostViewModel model = new PostViewModel() {Posts=posts,CurrentTopic=title };
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> AddPost()
        {

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var topicTitle = HttpContext.Request.Cookies["visited_topic"];
            var topic = await postService.GetCurrentTopic(topicTitle);

            var model = new PostViewModel()
            {
                UserId = userId,
                User = await postService.GetCurrentUser(userId),
                Date = DateTime.Now,
                Topic = topic,
                TopicId = topic.Id
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddPost(PostViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var post = await postService.CreateNewPost(model);
            await postService.AddNewPost(post);

            return RedirectToAction("GetAllPosts");
        }
    }
}
