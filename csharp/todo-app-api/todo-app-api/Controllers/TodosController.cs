using Microsoft.AspNetCore.Mvc;

namespace todo_app_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodosController : ControllerBase
    {
        // add a service to extract the logic

        private readonly ILogger<TodosController> _logger;

        public TodosController(ILogger<TodosController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetAllTodos")]
        [ProducesResponseType(typeof(Todo[]), StatusCodes.Status200OK)]

        public IEnumerable<Todo> GetAllTodos()
        {
            _logger.LogInformation("Fetching todos...");

            //retrieve todos from database

            return Enumerable.Range(1, 5).Select(index => new Todo
            {
                Date = DateTime.Now.AddDays(index),
                Name = $"Todo {index}",
                Completed = index % 2 == 0,
            })
            .ToArray();
        }

        [HttpGet("{name}", Name = "GetTodo")]
        [ProducesResponseType(typeof(Todo), StatusCodes.Status200OK)]
        public IActionResult GetTodo(string Name)
        {
            _logger.LogInformation("getting todo...");

            //fetch todo from database
            //if not found, return 404
            //if found, return todo

            Todo todo = new Todo
            {
                Date = DateTime.Now,
                Name = Name,
                Completed = true,
            };

            return Ok(todo);

        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Create([FromBody] Todo todo)
        {
            _logger.LogInformation("Saving todo...");
            //save todo to database

            return CreatedAtAction(nameof(GetTodo), new { name = todo.Name }, todo);
        }
    }
}
