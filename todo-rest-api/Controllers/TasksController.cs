using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace todo_rest_api
{
    [Route("/lists/{listId}/tasks/{taskId}")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        TasksListService toDoItemService;

        public TasksController(TasksListService toDoItemService)
        {
            this.toDoItemService = toDoItemService;
        }  

        [HttpGet]
        public ActionResult<Task> GetItemFromList(int listId, int taskId)        
        {
            return GetActionResult(toDoItemService.GetItemFromList(listId, taskId));
        }

        [HttpPut]
        public ActionResult<Task> ReplaceItem(int listId, int taskId, Task task)
        {
            return GetActionResult(toDoItemService.ReplaceItem(listId, taskId, task));
        }

        [HttpPatch]
        public ActionResult<Task> PartialUpdate(int listId, int taskId, Task task)
        {
            return GetActionResult(toDoItemService.PartialUpdate(listId, taskId, task));
        }
        
        [HttpDelete]
        public ActionResult DeleteItemFromList(int listId, int taskId)
        {
            return GetActionResult(toDoItemService.DeleteItemFromList(listId, taskId));
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