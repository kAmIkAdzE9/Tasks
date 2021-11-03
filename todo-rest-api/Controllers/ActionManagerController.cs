using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace todo_rest_api {

    [ApiController]
    public class ActionManagerController: ControllerBase 
    {
        protected ActionResult GetActionResult()
        {
            return Ok();
        }

        protected ActionResult<int> GetActionResult(int x)
        {
            return x;
        }

        protected ActionResult<Task> GetActionResult(Task task) 
        {
            if(task != null) {
                return task;
            }
            else {
                return NotFound();
            }
        }

        protected ActionResult<List<Task>> GetActionResult(List<Task> collection) 
        {
            if(collection != null) {
                return collection;
            }
            else {
                return NotFound();
            }
        }

        protected ActionResult<List<DashboardDTO>> GetActionResult(List<DashboardDTO> collection) 
        {
            if(collection != null) {
                return collection;
            }
            else {
                return NotFound();
            }
        }

        protected ActionResult<List<TaskListForTodayDTO>> GetActionResult(List<TaskListForTodayDTO> collection) 
        {
            if(collection != null) {
                return collection;
            }
            else {
                return NotFound();
            }
        }

        protected ActionResult<List<TaskListDTO>> GetActionResult(List<TaskListDTO> collection) 
        {
            if(collection != null) {
                return collection;
            }
            else {
                return NotFound();
            }
        }
    }
}