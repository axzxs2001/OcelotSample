
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebApiClient;
using WebApiClient.Attributes;
using WebApiClient.Contexts;
using WebApiClient.Interfaces;

namespace TestDesktop
{
    public partial class frmTest : Form
    {
        public frmTest()
        {
            InitializeComponent();
        }
        Result token;
        private void butLogin_Click(object sender, EventArgs e)
        {
            Login(delegate (Result r)
            {
                MessageBox.Show(r.access_token);
                token = r;
            }).GetAwaiter();
        }

        async Task Login(Action<Result> act)
        {
            var cfg = new HttpApiConfig();
            cfg.HttpHost = new Uri("http://127.0.0.1:5000");
            var myWebApi = HttpApiClient.Create<MyWebApi>(cfg);
            var userStr = await myWebApi.Login(new User { UserName = txbUserName.Text, Password = txbPassword.Text });
            myWebApi.Dispose();
            act(userStr);
        }


        private void btnQuery_Click(object sender, EventArgs e)
        {
            Query(delegate (dynamic json)
            {
                dataGridView1.DataSource = json;

            }).GetAwaiter();

        }
        async Task Query(Action<dynamic> act)
        {
            var cfg = new HttpApiConfig();
            cfg.HttpHost = new Uri("http://127.0.0.1:5000");
            cfg.GlobalFilters.Add(new GlobalFilter(token.token_type + " " + token.access_token));
            var myWebApi = HttpApiClient.Create<MyWebApi>(cfg);
            var json = await myWebApi.Query("amx");
            myWebApi.Dispose();
            act(json);
        }
    }



    #region 辅助类
    public interface MyWebApi : IDisposable
    {

        [HttpPost("/authapi/login")]
        ITask<Result> Login(User user);


        [HttpGet("/hisapi/getfeeitems")]
        ITask<dynamic> Query(string name);
    }

    public class Result
    {
        public bool status { get; set; }
        public string access_token { get; set; }

        public string expires_in { get; set; }
        public string token_type { get; set; }
    }

    public class User
    {
        public string UserName { get; set; }

        public string Password { get; set; }

    }

    public class GlobalFilter : IApiActionFilter
    {
        string _token;
        public GlobalFilter(string token)
        {
            _token = token;
        }
        public Task OnBeginRequestAsync(ApiActionContext context)
        {
            context.RequestMessage.Headers.Add("Authorization", _token);
            return Task.CompletedTask;
        }

        public Task OnEndRequestAsync(ApiActionContext context)
        {
            return Task.CompletedTask;
            //throw new NotImplementedException();
        }


    }

    #endregion
}
