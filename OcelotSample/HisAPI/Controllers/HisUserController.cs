using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using HisAPI.Model.Repository;
using Common;
using MimeKit;
using MailKit.Net.Smtp;
using System.Text;

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
       // [AllowAnonymous]
        [HttpPost("/notice")]
        public IActionResult Notice()
        {
            var bytes = new byte[10240];
            var i = Request.Body.ReadAsync(bytes, 0, bytes.Length);
            var content= System.Text.Encoding.UTF8.GetString(bytes).Trim('\0');
            SendEmail(content);
            return Ok();
        }

        void SendEmail(string content)
        {
           dynamic list= Newtonsoft.Json.JsonConvert.DeserializeObject(content);
            if(list != null&&list.Count>0)
            {
                var emailBody = new StringBuilder("健康检查故障:\r\n");            
                foreach(var noticy in list)
                {
                    emailBody.AppendLine($"--------------------------------------");
                    emailBody.AppendLine($"Node:{noticy.Node}");
                    emailBody.AppendLine($"Service ID:{noticy.ServiceID}");
                    emailBody.AppendLine($"Service Name:{noticy.ServiceName}");
                    emailBody.AppendLine($"Check ID:{noticy.CheckID}");
                    emailBody.AppendLine($"Check Name:{noticy.Name}");
                    emailBody.AppendLine($"Check Status:{noticy.Status}");
                    emailBody.AppendLine($"Check Output:{noticy.Output}");
                    emailBody.AppendLine($"--------------------------------------");
                }
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("gswmicroservice", "gswmicroservice@163.com"));
                message.To.Add(new MailboxAddress("285130205", "285130205@qq.com"));

                message.Subject = "作业报警";
                message.Body = new TextPart("plain") { Text = emailBody.ToString() };
                using (var client = new SmtpClient())
                {

                    client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                    client.Connect("smtp.163.com", 25, false);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    client.Authenticate("gswmicroservice", "gsw790622");
                    client.Send(message);
                    client.Disconnect(true);
                }
            }
       
        }

        /// <summary>
        /// 健康检查
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet("/health")]
        public IActionResult Health()
        {
            return Content("健康检查：正常");
        }
    }

}
