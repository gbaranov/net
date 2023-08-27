using System;
using Microsoft.EntityFrameworkCore;
using net.Domain;
namespace net.Data
{
	public class ApplicationDbContext: DbContext
	{
		public ApplicationDbContext(DbContextOptions options): base(options)
		{

		}

		public DbSet<BlogPost> BlogPosts { get; set; }

        public DbSet<Category> Categories { get; set; }

    }
}

