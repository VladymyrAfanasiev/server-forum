using ForumServisesDevelopment.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ForumServisesDevelopment.Data
{
	public class ForumDatabaseContext : DbContext
	{
		public ForumDatabaseContext(DbContextOptions<ForumDatabaseContext> options)
			: base(options)
		{

		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
		}

		public DbSet<Group> Groups { get; set; }
	}
}
