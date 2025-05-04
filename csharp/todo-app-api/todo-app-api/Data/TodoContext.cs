using Microsoft.EntityFrameworkCore;
using todo_app_api.Controllers;

namespace todo_app_api.Data
{
    public class TodoContext : DbContext
    {
        public DbSet<Todo> Todos { get; set; }

        public TodoContext(DbContextOptions<TodoContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Todo>().HasKey(t => t.Name); // Exemple de clé primaire
        }
    }
}
