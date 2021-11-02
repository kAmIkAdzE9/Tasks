using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace todo_rest_api
{
    [Route("/tasks")]
    [ApiController]
    public class TasksByParametersController : ActionManagerController
    {
        TasksListService toDoItemService;

        public TasksByParametersController(TasksListService toDoItemService)
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
    }
}