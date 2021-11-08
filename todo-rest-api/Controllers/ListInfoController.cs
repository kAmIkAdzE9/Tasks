using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace todo_rest_api
{
    [Route("")]
    [ApiController]
    public class ListInfoController : ActionManagerController 
    {
         ListInfoService listInfoService;

        public ListInfoController(ListInfoService listInfoService)
        {
            this.listInfoService = listInfoService;
        }  

        [HttpGet("dashboard")]
        public ActionResult<List<DashboardDTO>> GetListInfo()        
        {
            return GetActionResult(listInfoService.GetListInfo());
        }

        [HttpGet("collection/today")]
        public ActionResult<List<TaskWithTaskListDTO>> GetTaskListWithNonDoneTasksForToday()        
        {
            return GetActionResult(listInfoService.GetTaskListWithNonDoneTasksForToday());
        }

        [HttpGet("lists/{listId}/tasks")]
        public ActionResult<List<TaskWithTaskListDTO>> GetTaskList(int listId, bool all)        
        {
            return GetActionResult(listInfoService.GetTaskList(listId, all));
        }
    }
}