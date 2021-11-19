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
        public ActionResult<TaskWithoutTaskListDTO> GetItemFromList(int taskId)        
        {
            return GetActionResult(toDoItemService.GetItemFromList(taskId));
        }
        
        [HttpPost]
        public ActionResult<Task> CreateTaskInList(TaskWithoutTaskListDTO task)
        {
            return GetActionResult(toDoItemService.CreateTaskInList(task));
        }

        [HttpPut]
        public ActionResult<TaskWithoutTaskListDTO> ReplaceItem(int taskId, TaskWithoutTaskListDTO task)
        {
            return GetActionResult(toDoItemService.ReplaceItem(taskId, task));
        }

        [HttpPatch]
        public ActionResult<TaskWithoutTaskListDTO> PartialUpdate(int taskId, TaskWithoutTaskListDTO task)
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