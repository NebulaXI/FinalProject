using Microsoft.AspNetCore.Http;
using Moq;
using SkiProject.Core.Contracts;
using SkiProject.Infrastructure.Data.Common;
using SkiProject.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiProject.Test.Mocks
{
    public static class PostServiceMock
    {
        public static IPostService AllTopics
        {
            get
            {
                var postServiceMock = new Mock<IPostService>();
                postServiceMock.Setup(m => m.GetAllTopics())
                    .ReturnsAsync(Mock.Of<List<ForumTopic>>());

                return postServiceMock.Object;
            }
        }
        public static IPostService AllPosts
        {
            
            get
            {
                var postService = new Mock<IPostService>();
                postService.Setup(m=>m.GetAllPosts(It.IsAny<string>()))
                    .ReturnsAsync(Mock.Of<List<Post>>());
                return postService.Object;
            }
        }
        public static IPostService PostService
        {
            get
            {
                var postServiceMock = new Mock<IPostService>();
                return postServiceMock.Object;
            }
        }

        public static IRepository Repo
        {
            get
            {
                var repo = new Mock<IRepository>();
                return repo.Object;
            }
        }
    }
}
