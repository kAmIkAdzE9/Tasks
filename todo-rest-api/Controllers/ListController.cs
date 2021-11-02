using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace todo_rest_api
{
    [Route("/lists")]
    [ApiController]
    public class ListController : ActionManagerController 
    {
        TasksListService toDoItemService;

        public ListController(TasksListService toDoItemService)
        {
            this.toDoItemService = toDoItemService;
        }

        [HttpGet]
        public ActionResult<List<TaskList>> GetAll()
        {
            return toDoItemService.GetAll();
        }

        [HttpPost]
        public ActionResult CreateTasksList(string title)
        {
            toDoItemService.CreateTasksList(title);
            return Ok();
        }

        [HttpDelete]
        public ActionResult DeleteItem(int listId)
        { 
            toDoItemService.DeleteList(listId);
            return GetActionResult();
        }
    }
}