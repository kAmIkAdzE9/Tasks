using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace todo_rest_api
{
    [Route("/tasks")]
    [ApiController]
    public class TasksListByParametersController : ControllerBase
    {
        TasksListService toDoItemService;

        public TasksListByParametersController(TasksListService toDoItemService)
        {
            this.toDoItemService = toDoItemService;
        }

        [HttpGet("listId")]
        public ActionResult<List<Task>> GetList(int listId)
        {
            var list = toDoItemService.GetList(listId);
            return GetActionResult(list);
        }

        [HttpGet("listId/taskId")]
        public ActionResult<Task> GetItemFromList(int listId, int taskId)
        {
            var task = toDoItemService.GetItemFromList(listId, taskId);
            return GetActionResult(task);
        }

        [HttpPost("title")]
        public ActionResult CreateTasksList(string title)
        {
            toDoItemService.CreateTasksList(title);
            return GetActionResult(true);
        }

        [HttpPost("listId/task")]
        public ActionResult CreateTaskInList(int listId, Task task)
        {
            var status = toDoItemService.CreateTaskInList(listId, task);
            return GetActionResult(status);
        }

        [HttpPut("listId/taskId")]
        public ActionResult ReplaceItem(int listId, int taskId, Task task)
        {
            var status = toDoItemService.ReplaceItem(listId, taskId, task);
            return GetActionResult(status);
        }

        [HttpPatch("listId/taskId")]
        public ActionResult PartialUpdate(int listId, int taskId, Task task)
        {
            var status = toDoItemService.PartialUpdate(listId, taskId, task);
            return GetActionResult(status);
        }

        [HttpDelete("listId")]
        public ActionResult DeleteList(int listId)
        {
            var status = toDoItemService.DeleteList(listId);
            return GetActionResult(status);
        }

        [HttpDelete("listId/taskId/delete")]
        public ActionResult DeleteItemFromList(int listId, int taskId)
        {
            var status = toDoItemService.DeleteItemFromList(listId, taskId);
            return GetActionResult(status);
        }

        private ActionResult GetActionResult(bool status) 
        {
            if(status) {
                return Ok();
            }
            else {
                return NotFound();
            }
        }

        private ActionResult<List<Task>> GetActionResult(List<Task> collection) 
        {
            if(collection != null) {
                return collection;
            }
            else {
                return NotFound();
            }
        }

        private ActionResult<Task> GetActionResult(Task task) 
        {
            if(task != null) {
                return task;
            }
            else {
                return NotFound();
            }
        }
    }
}