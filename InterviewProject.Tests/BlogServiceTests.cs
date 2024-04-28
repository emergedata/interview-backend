using System.Collections.Generic;
using Moq;
using Xunit;

namespace InterviewProject.Tests;

public class BlogServiceTests
{
    public BlogServiceTests()
    {

    }

    [Fact]
    public void GetBlogFirstPostContent_BlogExists_ReturnContent()
    {
        // Arrange
        const int blogId = 1;
        var mockData = new Mock<IData>();
        mockData.Setup(d => d.Get(It.IsAny<int>())).Returns(new Blog { BlogId = blogId, Posts = new List<Post> { new Post { Content = $"This is the content of: {blogId}" } } });       
        var blogService = new Service(mockData.Object);
        var expectedResult = $"This is the content of: {blogId}";

        // Act
        var result = blogService.GetBlogFirstPostContent(blogId);

        // Assert
        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void GetBlogById_Calls_Data_Get_With_Id()
    {
        // Arrange
        var data = new Mock<IData>();
        var expected = new Blog { BlogId = 1, Url = "http://thisisatest.co" };
        data.Setup(d => d.Get(It.IsAny<int>())).Returns(expected);
        var service = new Service(data.Object);
        
        //Act
        var actual = service.GetBlogById(1);

        //Assert
        Assert.Equal(expected, actual);
        data.Verify(d => d.Get(1), Times.Once);
    }
}