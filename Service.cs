using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace InterviewProject
{   
    public class Service
    {
        public IData Data;
        public Service(IData data)
        {
            Data = data;
        }

        public string GetPostTitlesByBlogId(int id)
        {
            var titles = Data.GetBlogById(id).Posts.Select(p => p.Title);
            return string.Join(Environment.NewLine, titles);
        }

        public string GetLatestPostTitleByBlogId(int id)
        {
            return Data.GetBlogById(id).Posts.OrderByDescending(p => p.Published).First().Title;
        }

        public string GetFirstPostContentByBlogId(int id)
        {
            var blog = Data.GetBlogById(id);
            if(blog == null || blog.Posts.Count == 0)
            {
                return null;
            }
            return blog.Posts.First().Content;
        }

        public Post GetPostByTitle_StartsWithPost(string title)
        {
            if(!title.StartsWith("Post "))
            {
                title = $"Post {title}";
            }
            
            return Data.GetPost(title);
        }

        public Blog GetBlogById(int id)
        {
            return Data.GetBlogById(id);
        }
    }
}
