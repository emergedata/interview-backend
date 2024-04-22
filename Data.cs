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
    public class Data
    {
        private Ctx db;
        public Data() // don't change this constructor
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
        public Blog Get(int id)
        {
            return db.Blogs.FirstOrDefault(p => p.BlogId == id);
        }

        public Post GetPost(string title)
        {
            if (!Regex.IsMatch(title, @"\bpost\b"))
            {
                 throw new ArgumentException("Bad input");
            }
            return db.Posts.FirstOrDefault(p => p.Title == title);
        }
    }
}
