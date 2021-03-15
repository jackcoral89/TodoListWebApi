using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace TodoApi.Models
{
	public class TodoContext : DbContext
	{
		public TodoContext(DbContextOptions<TodoContext> options) : base(options) { }

		public DbSet<TodoItem> TodoItems { get; set; }
		// public IConfiguration Configuration { get; }

		// protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		// {
		// 	var connectionString = Configuration.GetConnectionString("DefaultConnection_Dev");
		// 	if (!optionsBuilder.IsConfigured)
		// 	{
		// 		optionsBuilder.UseSqlServer(connectionString);
		// 	}
		// }

	}
}