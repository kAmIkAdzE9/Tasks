using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace todo_rest_api
{
    [Route("/tasks/{taskId}")]
    [ApiController]
    public class TasksController : ActionManagerController
    {
        TasksListService toDoItemService;

        public TasksController(TasksListService toDoItemService)
        {
            this.toDoItemService = toDoItemService;
        }  

        [HttpGet]
        public ActionResult<Task> GetItemFromList(int taskId)        
        {
            return GetActionResult(toDoItemService.GetItemFromList(taskId));
        }

        [HttpPut]
        public ActionResult<Task> ReplaceItem(int taskId, Task task)
        {
            return GetActionResult(toDoItemService.ReplaceItem(taskId, task));
        }

        [HttpPatch]
        public ActionResult<Task> PartialUpdate(int taskId, Task task)
        {
            return GetActionResult(toDoItemService.PartialUpdate(taskId, task));
        }
        
        [HttpDelete]
        public ActionResult DeleteItemFromList(int taskId)
        {
            toDoItemService.DeleteItemFromList(taskId);
            return GetActionResult();
        }
    }
}