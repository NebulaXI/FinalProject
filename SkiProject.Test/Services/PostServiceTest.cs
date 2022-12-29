using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using SkiProject.Controllers;
using SkiProject.Core.Models;
using SkiProject.Core.Services;
using SkiProject.Infrastructure.Data.Common;
using SkiProject.Infrastructure.Data.Models;
using SkiProject.Infrastructure.Data.Models.Account;
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
        public async Task GetAllTopicsShouldReturnsCorrectAnswear()
        {
            //Arrange
            var data = DBMock.Instance;
            var repo = new Repository(data);
            var postService = new PostService(repo);
            var topics = new List<ForumTopic>();
            for (int i = 0; i < 10; i++)
            {
                topics.Add(new ForumTopic() { CommentsCount = i,Title = i.ToString()});
            }
            foreach (var item in topics)
            {
                data.Topics.Add(item);
            }
            data.SaveChanges();


            var getAllTopics = await postService.GetAllTopics();


            Assert.NotNull(getAllTopics);
            Assert.Equal(10,getAllTopics.Count);
        }

        [Fact]
        public async Task GetTopicsToDeleteShouldReturnTopicsCreatedByTheUserId()
        {
            var data = DBMock.Instance;
            var repo = new Repository(data);
            var postService = new PostService(repo);
            var topics = new List<ForumTopic>();
            for (int i = 0; i < 3; i++)
            {
                topics.Add(new ForumTopic() { CommentsCount = i, Title = i.ToString(),CreatedByUserId="1" });
            }
            for (int i = 0; i < 3; i++)
            {
                topics.Add(new ForumTopic() { CommentsCount = i, Title = i+1.ToString(), CreatedByUserId = "2" });
            }
            foreach (var item in topics)
            {
                data.Topics.Add(item);
            }
            data.SaveChanges();
            var userId = "2";

            var getTopicsToDelete = await postService.GetTopicsToDelete(userId);


            Assert.NotNull(getTopicsToDelete);
            Assert.Equal(3, getTopicsToDelete.Count);
        }

        [Fact]
        public async Task GetCurrentTopicByIdShouldReturnTheCorrectTopic()
        {
            var data = DBMock.Instance;
            var repo = new Repository(data);
            var postService = new PostService(repo);
            var forumController = new ForumController(postService);
            var topics = new List<ForumTopic>();
            for (int i = 0; i < 4; i++)
            {
                topics.Add(new ForumTopic() { CommentsCount = i, Title = i.ToString()});
            }
            var topicId = 0;
            ForumTopic expected = null;
            foreach (var item in topics)
            {
                data.Topics.Add(item);
                topicId = item.Id;
                expected = item;
            }
            data.SaveChanges();
            
            var result = await postService.GetCurrentTopicById(topicId);

            Assert.Equal(expected, result);
        }
        [Fact]
        public async Task GetCurrentTopicShouldReturnTheCorrectTopic()
        {
            var data = DBMock.Instance;
            var repo = new Repository(data);
            var postService = new PostService(repo);
            var topics = new List<ForumTopic>();
            for (int i = 0; i < 4; i++)
            {
                topics.Add(new ForumTopic() { CommentsCount = i, Title = i.ToString() });
            }
            string topicTitle =null;
            ForumTopic expected = null;
            foreach (var item in topics)
            {
                data.Topics.Add(item);
                topicTitle =item.Title;
                expected = item;
            }
            data.SaveChanges();

            var result = await postService.GetCurrentTopic(topicTitle);

            result.Should().NotBeNull();
        }

        [Fact]
        public async Task DeleteCurrentTopicShouldDeleteTheTopic()
        {
            var data = DBMock.Instance;
            var repo = new Repository(data);
            var postService = new PostService(repo);
            var topics = new List<ForumTopic>();
            for (int i = 0; i < 4; i++)
            {
                topics.Add(new ForumTopic() { CommentsCount = i, Title = i.ToString() });
            }
            ForumTopic topic = null;
            foreach (var item in topics)
            {
                data.Topics.Add(item);
                topic = item;
            }
            data.SaveChanges();

            var result = await postService.DeleteCurrentTopic(topic);

            result.Should().NotContain(topic);
        }

        [Fact]
        public async Task GetAllPostsShouldReturnAllPosts()
        {
            var data = DBMock.Instance;
            var repo = new Repository(data);
            var postService = new PostService(repo);
            var topic1 = new ForumTopic() { CommentsCount = 4, Title = "1",Posts=new List<Post>()};
            for (int i = 0; i < 4; i++)
            {
                topic1.Posts.Add(new Post() {UserId="1",TopicId=topic1.Id,Date=DateTime.Now,Content=i.ToString()});
            }
            var topic2 = new ForumTopic() { CommentsCount = 4, Title = "2", Posts = new List<Post>() };
            for (int i = 0; i < 4; i++)
            {
                topic2.Posts.Add(new Post() { UserId = "1", TopicId = topic2.Id, Date = DateTime.Now, Content = i.ToString() });
            }
            data.Topics.Add(topic1);
            data.Topics.Add(topic2);
            data.SaveChanges();


            var result = await postService.GetAllPosts(topic1.Id);


            Assert.Equal(4,result.Count);
        }

        [Fact]
        public async Task GetCurrentUserShouldReturnUserById()
        {
            var data = DBMock.Instance;
            var repo = new Repository(data);
            var postService = new PostService(repo);
            var users = new List<ApplicationUser>();
            for (int i = 0; i < 3; i++)
            {
                users.Add(new ApplicationUser()
                {
                    FirstName = i.ToString(),
                    LastName = i.ToString(),
                    Birthday=DateTime.Now,
                    UserName=i.ToString(),
                    Email=$"{i.ToString()}@mail.com"
                });
            }
            string userId = null;
            foreach (var item in users)
            {
                await data.Users.AddAsync(item);
                userId = item.Id;
            }
            data.SaveChanges();


            var result = await postService.GetCurrentUser(userId);


            result.Should().NotBeNull();
            result.Id.Should().Be(userId);
        }

        [Fact]
        public async Task CreateTopicShouldCreate()
        {
            var data = DBMock.Instance;
            var repo = new Repository(data);
            var postService = new PostService(repo);
            var userId = "1";
            var model1 = new NewTopicViewModel()
            {
                Title = "1",
                Content = "1",
                CreatedOn = DateTime.Now,
                LastUpdated = DateTime.Now,
                CommentsCount = 1,
                CreatedByUserId=userId,
                Posts = new List<Post>()
                {
                   new Post()
                   {
                       UserId = userId, TopicId = 1, Date = DateTime.Now, Content = "1"
                   }
                }
            };
            var model2 = new NewTopicViewModel()
            {
                Title = "2",
                Content = "2",
                CreatedOn = DateTime.Now,
                LastUpdated = DateTime.Now,
                CommentsCount=1,
                CreatedByUserId=userId,
                Posts = new List<Post>()
                {
                   new Post()
                   {
                       UserId = userId, TopicId = 1, Date = DateTime.Now, Content = "1"
                   }
                }
            };


            var topic1= await postService.CreateTopic(model1);
            data.Topics.Add(topic1);
            var topic2=await postService.CreateTopic(model2);
            data.Topics.Add(topic2);
            await data.SaveChangesAsync();

            Assert.Equal(2, data.Topics.Count());
        }

        [Fact]
        public async Task AddNewPostShouldAdd()
        {
            var data = DBMock.Instance;
            var repo = new Repository(data);
            var postService = new PostService(repo);
            var topic1 = new ForumTopic() { CommentsCount = 4, Title = "1", Posts = new List<Post>() };
            for (int i = 0; i < 4; i++)
            {
                topic1.Posts.Add(new Post() { UserId = "1",Topic=topic1, TopicId = topic1.Id, Date = DateTime.Now, Content = i.ToString() });
                
            }
            data.Topics.Add(topic1);
            await data.SaveChangesAsync();

            foreach (var item in topic1.Posts.ToList())
            {
                await postService.AddNewPost(item);
            }
            await data.SaveChangesAsync();

            Assert.Equal(4, data.Posts.Count());
        }

        [Fact]
        public async Task AddNewTopicShouldAdd()
        {
            var data = DBMock.Instance;
            var repo = new Repository(data);
            var postService = new PostService(repo);
            var topic1 = new ForumTopic() { CommentsCount = 4, Title = "1", Posts = new List<Post>() };
            for (int i = 0; i < 4; i++)
            {
                topic1.Posts.Add(new Post() { UserId = "1", Topic = topic1, TopicId = topic1.Id, Date = DateTime.Now, Content = i.ToString() });

            }

            await postService.AddNewTopic(topic1);

            Assert.Equal(1,data.Topics.Count());
        }
    }
}
