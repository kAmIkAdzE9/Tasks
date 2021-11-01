using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ef_blog
{
    class Program
    {
        public class BloggingContext : DbContext
        {
            public DbSet<Blog> Blogs { get; set; }
            public DbSet<Post> Posts { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder
                    .LogTo(Console.WriteLine)
                    .UseSnakeCaseNamingConvention()
                    .UseNpgsql("Host=127.0.0.1;Username=blog_app;Password=blog;Database=blog");
            }
        }

        public class Blog
        {
            public int BlogId { get; set; }
            public string Url { get; set; }
            public int Rating { get; set; }
            public List<Post> Posts { get; set; }
        }

        public class Post
        {
            public int PostId { get; set; }
            public string Title { get; set; }
            public string Content { get; set; }

            public int BlogId { get; set; }
            public Blog Blog { get; set; }
        }
        static void Main(string[] args)
        {
            using(var db = new BloggingContext()) {
                var alexBlog = db.Blogs
                    .Where(b => b.BlogId == 1)
                    .Include(b => b.Posts)
                    .Single();
                
                foreach(var post in alexBlog.Posts) {
                    Console.WriteLine(post);
                }

                var secondPost = new Post() {
                    Blog = alexBlog,
                    Title = "My first post"
                };

                alexBlog.Posts.Add(secondPost);
                
                db.SaveChanges();
            }
        }
    }
}