using System;
using System.Linq;

namespace InterviewProject
{
    public class Service
    {
        public IData Data;
        public Service(IData data)
        {
            Data = data;
        }

        public string A(int id)
        {
            var titles = Data.Get(id).Posts.Select(p => p.Title);
            return string.Join(Environment.NewLine, titles);
        }

        public string B(int id)
        {
            return Data.Get(id).Posts.OrderByDescending(p => p.Published).First().Title;
        }

        /// <summary>
        /// Get blog first post content
        /// </summary>
        /// <param name="id">The blog Id</param>
        /// <returns>The content of the first post of the blog</returns>
        public string GetBlogFirstPostContent(int id)
        {
            return Data.Get(id).Posts.First().Content;
        }

        public Post D(string title)
        {
            return Data.GetPost(title);
        }
        public Blog GetBlogById(int id)
        {
            return Data.Get(id);
        }
    }
}