using System;
using System.Collections.Generic;
using Moq;
using Xunit;

namespace InterviewProject.Tests
{
    public class BlogServiceTests
    {
        public Mock<IData> GetMockData()
        {
            var mockData = new Mock<IData>();
            mockData.Setup(d => d.GetBlogById(2)).Returns(new Blog
            {
                BlogId = 1,
                Url = "http://thisisatest.co",
                Posts = new List<Post>()
                
            });
            mockData.Setup(d => d.GetBlogById(1)).Returns(new Blog
            {
                BlogId = 1,
                Url = "http://thisisatest.co",
                Posts = new List<Post>
                {
                    new Post
                    {
                        PostId = 1,
                        Title = "Post 1",
                        BlogId = 1,
                        Content = "This is the content of: 1",
                        Published = DateTime.Parse("2021-01-01T23:59:58Z")
        },
                    new Post
                    {
                        PostId = 2,
                        Title = "Post 2",
                        BlogId = 1,
                        Content = "This is the content of: 2",
                        Published = DateTime.Parse("2021-01-01T23:59:59Z")
        }
                }
            });
            return mockData;
        }

        [Fact]
        public void GetFirstPostContentByBlogId_ReturnsFirstPostsContent()
        {
            var mockData = GetMockData();
            
            var blogService = new Service(mockData.Object);
            var blogId = 1;
            var actualResult = blogService.GetFirstPostContentByBlogId(blogId);
            var expectedResult = $"This is the content of: {blogId}";
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void GetFirstPostContentByBlogId_ReturnsNullIfNotFound()
        {
            var mockData = GetMockData();

            var blogService = new Service(mockData.Object);
            var blogId = 0;
            var actualPostContent = blogService.GetFirstPostContentByBlogId(blogId);
            Assert.Null(actualPostContent);
        }
        [Fact]
        public void GetFirstPostContentByBlogId_IfBlogWithNoPosts_ReturnsNull()
        {
            var mockData = GetMockData();

            var blogService = new Service(mockData.Object);
            var blogId = 2;
            var actualPostContent = blogService.GetFirstPostContentByBlogId(blogId);
            Assert.Null(actualPostContent);
        }

        [Fact]
        public void GetLatestPostTitleByBlogId_ReturnsLatestPostTitle()
        {
            var mockData = GetMockData();
            
            var blogService = new Service(mockData.Object);
            var blogId = 1;
            var actualResult = blogService.GetLatestPostTitleByBlogId(blogId);
            var expectedResult = "Post 2";
            Assert.Equal(expectedResult, actualResult);
        }
        [Fact]
        public void GetPostTitlesByBlogId_ReturnsPostTitles()
        {
            var mockData = GetMockData();
            
            var blogService = new Service(mockData.Object);
            var blogId = 1;
            var actualResult = blogService.GetPostTitlesByBlogId(blogId);
            var expectedResult = $"Post 1{Environment.NewLine}Post 2";
            Assert.Equal(expectedResult, actualResult);
        }
        
    }
}
