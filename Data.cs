using System;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;

namespace InterviewProject
{
    public class Ctx : DbContext
    {
        public Ctx(DbContextOptions<Ctx> options)
            : base(options)
        { }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Blog> Blogs { get; set; }
    }
    public interface IData 
    {
        Blog GetBlogById(int id);

        Post GetPost(string title);
    }
    public class Data: IData
    {
        private Ctx db;
        public Data() // don't change this constructor data is unmodifyable
        {
            var options = new DbContextOptionsBuilder<Ctx>()
                .UseInMemoryDatabase(databaseName: "Test")
                .Options;

            db = new Ctx(options);
            for (int i = 1; i < 10; i++)
            {
                var post = new Post
                {
                    PostId = i,
                    Title = $"Post {i} " + Guid.NewGuid(),
                    BlogId = 1,
                    Content = $"This is the content of: {i}",
                    Published = DateTime.Now
                };

                db.Posts.Add(post);
                db.SaveChanges();
            }
            var blog = new Blog
            {
                BlogId = 1,
                Url = "http://thisisatest.co",
                Posts = db.Posts.ToList()
            };
            db.Blogs.Add(blog);
            db.SaveChanges();
        }
        public Blog GetBlogById(int id)
        {
            return db.Blogs.FirstOrDefault(p => p.BlogId == id);
        }

        public Post GetPost(string title)
        {
            // this validation might be in the wrong layer
            
            return db.Posts.FirstOrDefault(p => p.Title == title);
        }
    }
}
