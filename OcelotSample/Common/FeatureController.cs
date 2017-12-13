using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public class FeatureController:Controller
    {
        [AllowAnonymous]
        [HttpGet("/getactions")]
        public IActionResult GetAllAction()
        {
            var actions = ActionHandle.GetActions();
            return new JsonResult(actions);
        }
    }
}
