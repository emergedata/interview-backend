using Xunit;

namespace InterviewProject.Tests;

public class BlogServiceTests
{
    [Fact]
    public void GetBlogFirstPostContent_BlogExists_ReturnContent()
    {
        // Arrange
        const int blogId = 1;
        var blogService = new Service();
        var expectedResult = $"This is the content of: {blogId}";

        // Act
        var result = blogService.GetBlogFirstPostContent(blogId);

        // Assert
        Assert.Equal(expectedResult, result);
    }
}