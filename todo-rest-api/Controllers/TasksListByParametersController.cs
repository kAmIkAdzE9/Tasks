using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace todo_rest_api
{
    [Route("/lists")]
    [ApiController]
    public class TasksListByParametersController : ControllerBase
    {
        TasksListService toDoItemService;

        public TasksListByParametersController(TasksListService toDoItemService)
        {
            this.toDoItemService = toDoItemService;
        }

        [HttpGet("listId")]
        public ActionResult<TaskList> GetAllFromList(int listId)
        {
            return toDoItemService.GetAllFromList(listId);
        }

        [HttpGet("listId/taskId")]
        public ActionResult<Task> GetItemFromList(int listId, int taskId)
        {
            return toDoItemService.GetItemFromList(listId, taskId);
        }

        [HttpPost("title")]
        public void CreateTodoItemInList(string title)
        {
            toDoItemService.CreateTasksList(title);
        }

        [HttpPost("listId/toDoItem")]
        public void CreateTodoItemInList(int listId, Task task)
        {
            toDoItemService.CreateTaskInList(listId, task);
        }

        [HttpPut("listId/taskId")]
        public void ChangeFullItem(int listId, int taskId, Task task)
        {
            toDoItemService.ReplaceItem(listId, taskId, task);
        }

        [HttpPatch("listId/taskId")]
        public void ChangeTitle(int listId, int taskId, Task task)
        {
            toDoItemService.PartialUpdate(listId, taskId, task);
        }

        [HttpDelete("listId")]
        public void DeleteItem(int listId)
        {
            toDoItemService.DeleteList(listId);
        }

        [HttpDelete("listId/taskId/delete")]
        public void DeleteItem(int listId, int taskId)
        {
            toDoItemService.DeleteItemFromList(listId, taskId);
        }
    }
}