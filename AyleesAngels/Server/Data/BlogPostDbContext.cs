using AyleesAngels.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AyleesAngels.Server.Data
{
    public class BlogPostDbContext : DbContext
    {
        public BlogPostDbContext(DbContextOptions<BlogPostDbContext> options) : base(options)
        {

        }
        public DbSet<BlogPost> BlogPosts { get; set; }
    }
}
