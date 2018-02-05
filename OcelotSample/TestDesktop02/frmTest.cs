using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Refit;

namespace TestDesktop02
{
    public partial class frmTest : Form
    {
        public frmTest()
        {
            InitializeComponent();
        }

        ITestWebApi _testAPI;
        Result _token;
        private void butLogin_Click(object sender, EventArgs e)
        {
            //登录获取Token
            var testAPI = RestService.For<ITestWebApi>("http://127.0.0.1:5000");
            _token = testAPI.Login(txbUserName.Text, txbPassword.Text).GetAwaiter().GetResult();

            //初始化通用接口
            _testAPI = RestService.For<ITestWebApi>(new HttpClient(new AuthenticatedHttpClientHandler(_token.access_token)) { BaseAddress = new Uri("http://127.0.0.1:5000") });
            butLogin.Enabled = false;
            
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _testAPI.Query(txbQuery.Text).GetAwaiter().GetResult();
        }

        private void frmTest_Load(object sender, EventArgs e)
        {

        }
    }


    public interface ITestWebApi
    {
        [Post("/authapi/login")]
        Task<Result> Login(string username, string password);


        [Get("/hisapi/getfeeitems")]
        [Headers("Authorization: Bearer")]
        Task<dynamic> Query(string name);
    }
    class AuthenticatedHttpClientHandler : HttpClientHandler
    {   

        string _token;
        public AuthenticatedHttpClientHandler(string token)
        {
            _token = token;
        }
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // See if the request has an authorize header
            var auth = request.Headers.Authorization;
            if (auth != null)
            {
                // var token = await getToken().ConfigureAwait(false);
                request.Headers.Authorization = new AuthenticationHeaderValue(auth.Scheme, _token);
            }

            return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
        }
    }

    #region 辅助类
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
    #endregion
}
