using SkiProject.Infrastructure.Data.Models;
using SkiProject.Test.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiProject.Test.Services
{
    public class PostServiceTest
    {

        [Fact]
        public void Is_AddNewPost_Adds_A_New_Post(Post post)
        {
            var before = PostServiceMock.AllPosts;
            var after = PostServiceMock.PostService.AddNewPost(post);
        }
    }
}
