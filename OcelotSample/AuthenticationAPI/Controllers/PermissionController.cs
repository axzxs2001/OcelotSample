
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using System;
using Ocelot.JWTAuthorizePolicy;
using MimeKit;
using MailKit.Net.Smtp;
using System.Text;

namespace AuthenticationAPI
{
    [Authorize("Permission")]
    public class PermissionController : Controller
    {
        /// <summary>
        /// 自定义策略参数
        /// </summary>
        PermissionRequirement _requirement;
        public PermissionController(PermissionRequirement requirement)
        {
            _requirement = requirement;
        }
        [AllowAnonymous]
        [HttpPost("/authapi/login")]
        public IActionResult Login(string username, string password)
        {
            var isValidated = (username == "gsw" && password == "111111")|| (username == "ggg" && password == "222222");
            var role=username=="gsw"?"admin" :"system";
            if (!isValidated)
            {
                return new JsonResult(new
                {
                    Status = false,
                    Message = "认证失败"
                });
            }
            else
            {               
                //如果是基于用户的授权策略，这里要添加用户;如果是基于角色的授权策略，这里要添加角色
                var claims = new Claim[] { new Claim(ClaimTypes.Name, username), new Claim(ClaimTypes.Role, role), new Claim(ClaimTypes.Expiration ,DateTime.Now.AddSeconds(_requirement.Expiration.TotalSeconds).ToString())};

                //用户标识
                var identity = new ClaimsIdentity(JwtBearerDefaults.AuthenticationScheme);
                identity.AddClaims(claims);
             
                var token = JwtToken.BuildJwtToken(claims, _requirement);
                return new JsonResult(token);
            }
        }


   
        [HttpPost("/notice")]
        public IActionResult Notice()
        {
            var bytes = new byte[10240];
            var i = Request.Body.ReadAsync(bytes, 0, bytes.Length);
            var content = System.Text.Encoding.UTF8.GetString(bytes).Trim('\0');
            SendEmail(content);
            return Ok();
        }
        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="content"></param>
        void SendEmail(string content)
        {
            try
            {
                dynamic list = Newtonsoft.Json.JsonConvert.DeserializeObject(content);
                if (list != null && list.Count > 0)
                {
                    var emailBody = new StringBuilder("健康检查故障:\r\n");
                    foreach (var noticy in list)
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
                    //这里是测试邮箱，请不要发垃圾邮件，谢谢
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
            catch
            {

            }

        }
    }
}
