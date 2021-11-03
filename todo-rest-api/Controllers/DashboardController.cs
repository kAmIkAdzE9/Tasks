using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace todo_rest_api
{
    [Route("/dashboard")]
    [ApiController]
    public class DashboardController : ActionManagerController 
    {
         ListInfoService listInfoService;

        public DashboardController(ListInfoService listInfoService)
        {
            this.listInfoService = listInfoService;
        }  

        [HttpGet]
        public ActionResult<List<ListInfoDTO>> GetListInfo()        
        {
            return GetActionResult(listInfoService.GetListInfo());
        }
    }
}