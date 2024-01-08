using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using BlogApp.Models;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace BlogApp.Data
{
    public class BlogAppContext : IdentityDbContext<AppUser>
    {
        protected readonly IConfiguration Configuration;
        public BlogAppContext (IConfiguration configuration)
        {
            Configuration = configuration;
        }
  
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnectionString"));
        }

        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}