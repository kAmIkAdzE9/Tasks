using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace todo_rest_api
{
    [Route("/lists/{listId}")]
    [ApiController]
    public class TasksListController : ActionManagerController
    {
        TasksListService toDoItemService;

        public TasksListController(TasksListService toDoItemService)
        {
            this.toDoItemService = toDoItemService;
        }  

        [HttpGet]
        public ActionResult<List<Task>> GetList(int listId)
        {
            return GetActionResult(toDoItemService.GetList(listId));
        }

        [HttpPost]
        public ActionResult<Task> CreateTaskInList(int listId, Task task)
        {
            return GetActionResult(toDoItemService.CreateTaskInList(listId, task));
        }
    
        [HttpDelete]
        public ActionResult DeleteItem(int listId)
        { 
            return GetActionResult(toDoItemService.DeleteList(listId));
        }
    }
}