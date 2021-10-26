using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace todo_rest_api
{
    public class TodoItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }
        public bool Done { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemController : ControllerBase
{
    static private List<TodoItem> todoItems = new List<TodoItem> {
        new TodoItem() { Id = 1, Title = "Implement read" },
        new TodoItem() { Id = 2, Title = "Implement create" }
    };
    static private int lastId = 2;

    [HttpGet("")]
    public ActionResult<IEnumerable<TodoItem>> GetTodoItems()
    {
        return todoItems;
    }

    [HttpPost("")]
    public ActionResult<TodoItem> CreateTodoItem(TodoItem todoItem)
    {
        todoItem.Id = ++lastId;
        todoItems.Add(todoItem);
        return Created($"api/todoitem/{todoItem.Id}", todoItem);
    }
}
}