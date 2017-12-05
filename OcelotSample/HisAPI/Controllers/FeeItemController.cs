using HisAPI.Model.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HisAPI.Controllers
{
    /// <summary>
    /// 收费controller
    /// </summary>
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
            var list = _feeItemRepository.GetFeeItem(name);
            return new JsonResult(list);
        }
    }
}
