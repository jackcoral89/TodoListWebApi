using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoListApp.Models
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }

        public DbSet<TodoItem> TodoItems { get; set; }
    }
}
