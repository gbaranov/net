using System;
using Microsoft.EntityFrameworkCore;
using net.Models.Domain;
namespace net.Data
{
	public class ApplicationDbContext: DbContext
	{
		public ApplicationDbContext(DbContextOptions options): base(options)
		{

		}

		public DbSet<BlogPost>
		
	}
}

