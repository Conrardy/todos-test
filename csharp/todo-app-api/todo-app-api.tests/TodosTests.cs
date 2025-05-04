using Microsoft.EntityFrameworkCore;
using todo_app_api.Data;

namespace todo_app_api.tests
{
    public class TodosTests
    {
        private TodoContext GetContext()
        {
            var options = new DbContextOptionsBuilder<TodoContext>().
                UseSqlite("Data Source = todotest.db")
                .Options;

            var db = new TodoContext(options);

            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            return db;
        }

        [Fact]
        public void TestTodo()
        {
            // Arrange: Configure une base de données SQLite en mémoire
            var context = GetContext();

        }
    }
}