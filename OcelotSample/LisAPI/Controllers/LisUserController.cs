using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Common;

namespace LisAPI.Controllers
{
    [Authorize("Permission")]
    [Route("lisapi/[controller]")]
    public class LisUserController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Lis用户服务", "保存用户" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        [AllowAnonymous]
        [HttpGet("/")]
        public IEnumerable<string> ABC()
        {
            return new string[] { "Lis用户服务", "首页" };
        }
        [AllowAnonymous]
        [HttpGet("/lisapi/denied")]
        public IActionResult Denied()
        {
            return new JsonResult(new
            {
                Status = false,
                Message = "Lis你无权限访问"
            });
        }

  
    }
}



