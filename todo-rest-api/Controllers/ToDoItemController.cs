using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace todo_rest_api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoItemController : ControllerBase
    {
        private ToDoItemService toDoItemService;

        public ToDoItemController(ToDoItemService service)
        {
            this.toDoItemService = service;
        }

        [HttpGet("")]
        public ActionResult<IEnumerable<ToDoItem>> GetTodoItems()
        {
            return toDoItemService.GetALL();
        }

        [HttpPost("")]
        public ActionResult<ToDoItem> CreateTodoItem(ToDoItem todoItem)
        {
            ToDoItem createdItem = toDoItemService.Create(todoItem);
            return Created($"api/todoitem/{createdItem.Id}", createdItem);
        }

        [HttpPut("{itemID}")]
        public ActionResult<ToDoItem> ChangeFullItem(int itemID, ToDoItem toDoItem)
        {
            ToDoItem createdItem = toDoItemService.ChangeFullItem(itemID, toDoItem);
            return Created($"api/todoitem/{createdItem.Id}", createdItem);
        }

        [HttpPatch("title/{itemID}/{title}")]
        public ActionResult<ToDoItem> ChangeTitle(int itemID, string title)
        {
            ToDoItem createdItem = toDoItemService.ChangeTitle(itemID, title);
            return Created($"api/todoitem/{createdItem.Id}", createdItem);
        }

        [HttpPatch("description/{itemID}/{description}")]
        public ActionResult<ToDoItem> ChangeDescription(int itemID, string description)
        {
            ToDoItem createdItem = toDoItemService.ChangeDescription(itemID, description);
            return Created($"api/todoitem/{createdItem.Id}", createdItem);
        }

        [HttpPatch("date/{itemID}/{date}")]
        public ActionResult<ToDoItem> ChangeDate(int itemID, DateTime date)
        {
            ToDoItem createdItem = toDoItemService.ChangeDate(itemID, date);
            return Created($"api/todoitem/{createdItem.Id}", createdItem);
        }

        [HttpPatch("done/{itemID}/{done}")]
        public ActionResult<ToDoItem> ChangeDone(int itemID, bool done)
        {
            ToDoItem createdItem = toDoItemService.ChangeDone(itemID, done);
            return Created($"api/todoitem/{createdItem.Id}", createdItem);
        }

        [HttpDelete("{itemID}")]
        public void DeleteItem(int itemID)
        {
            toDoItemService.Delete(itemID);
        }
    }
}