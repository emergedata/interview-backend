using System;
using Xunit;

namespace InterviewProject.Tests
{
    public class BlogServiceTests
    {
        [Fact]
        public void C_Formats_result_as_expected()
        {
            var blogService = new Service();
            var blogId = 1;
            var actualResult = blogService.C(blogId);
            var expectedResult = $"This is the content of: {blogId}";
            Assert.Equal(expectedResult, actualResult);
        }
    }
}
