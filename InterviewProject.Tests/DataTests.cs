using System;
using System.Linq;
using Xunit;

namespace InterviewProject.Tests;

public class DataTests
{
    private readonly Data _data = new();

    // [Fact]
    // public void GetPost_WithPostInTitle_ReturnPost()
    // {
    //     // Arrange
    //     var blog = _data.Get(1);
    //     var title = blog.Posts.First().Title;
    //
    //     // Act
    //     var post = _data.GetPost(title);
    //
    //     // Assert
    //     Assert.Equal(title, post.Title);
    // }

    [Fact]
    public void GetPost_WithoutPostInTitle_ThrowException()
    {
        // Arrange
        const string title = "hello";

        // Act
        Action act = () => _data.GetPost(title);

        // Assert
        var exception = Assert.Throws<ArgumentException>(act);
        Assert.Contains("Bad input", exception.Message);
    }
}