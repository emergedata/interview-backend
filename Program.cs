using System;

namespace InterviewProject
{
    class Program
    {
        // Goals:
        // 1. Refactor the code to get maximum test coverage
        // 2. Make sure the code is clean and easy to read
        // 3. Make sure the code is easy to maintain

        static void Main(string[] args)
        {
            var data = new Data();
            var service = new Service(data);
            var a = service.GetBlogById(1);
            Console.WriteLine($"Blog: {a.BlogId}");
            Console.WriteLine(service.GetPostTitlesByBlogId(1));
            Console.WriteLine("Latest: " + service.GetLatestPostTitleByBlogId(1));
            Console.Write("Enter a post to see details: Post ");
            var input = Console.ReadLine();
            //we now have logic externally from the service though
            
            Console.WriteLine($"Searching for posts with title: 'Post {input}'");
            // eg: append Post + input
            Console.WriteLine(service.GetPostByTitle_StartsWithPost(input));
        }
    }
}
