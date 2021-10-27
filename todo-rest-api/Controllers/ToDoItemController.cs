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

        public ToDoItemController (ToDoItemService service) {
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

        [HttpPatch("{itemID}")]
        public ActionResult<ToDoItem> ChangeDone(int itemID)
        {
            ToDoItem createdItem = toDoItemService.ChangeDone(itemID);
            return Created($"api/todoitem/{createdItem.Id}", createdItem);
        }

        [HttpPatch("{itemID}/{done}")]
        public ActionResult<ToDoItem> ChangeDone(int itemID, bool done)
        {
            ToDoItem createdItem = toDoItemService.ChangeDone(itemID, done);
            return Created($"api/todoitem/{createdItem.Id}", createdItem);
        }

        [HttpDelete("{itemID}")]
        public void DeleteItem(int itemID) {
            toDoItemService.Delete(itemID);
        }
    }
}