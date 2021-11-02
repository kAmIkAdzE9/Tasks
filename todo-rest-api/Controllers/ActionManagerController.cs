using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace todo_rest_api {

    [ApiController]
    public class ActionManagerController: ControllerBase 
    {
        protected ActionResult<Task> GetActionResult(Task task) 
        {
            if(task != null) {
                return task;
            }
            else {
                return NotFound();
            }
        }

        protected ActionResult GetActionResult(bool status) 
        {
            if(status) {
                return Ok();
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
    }
}