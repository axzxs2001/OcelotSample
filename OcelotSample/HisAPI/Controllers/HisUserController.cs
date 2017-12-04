using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using HisAPI.Model.Repository;

namespace HisAPI.Controllers
{
    [Authorize("Permission")]
    [Route("hisapi/[controller]")]
    public class HisUserController : Controller
    {
        IFeeItemRepository _feeItemRepository;
        public HisUserController(IFeeItemRepository feeItemRepository)
        {
            _feeItemRepository = feeItemRepository;
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "His用户服务", "请求用户" };
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
        [HttpGet("/hisapi/denied")]
        public IActionResult Denied()
        {
            return new JsonResult(new
            {
                Status = false,
                Message = "His你无权限访问"
            });
        }


    }



    [Authorize("Permission")]
    public class FeeItemController : Controller
    {
        IFeeItemRepository _feeItemRepository;
        public FeeItemController(IFeeItemRepository feeItemRepository)
        {
            _feeItemRepository = feeItemRepository;
        }
        [HttpGet("/hisapi/getfeeitems")]
        public IActionResult GetFeeItem(string name)
        {
            var list = _feeItemRepository.GetFeeItems(name);
            return new JsonResult(list);
        }
    }
}
