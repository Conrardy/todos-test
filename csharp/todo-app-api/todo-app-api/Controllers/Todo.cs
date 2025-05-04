
namespace todo_app_api.Controllers
{
    public class Todo
    {
        public DateTime Date { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool Completed { get; set; }
    }
}