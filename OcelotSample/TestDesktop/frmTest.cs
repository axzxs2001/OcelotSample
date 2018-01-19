
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

namespace TestDesktop
{
    public partial class frmTest : Form
    {
        public frmTest()
        {
            InitializeComponent();
        }

        private void butLogin_Click(object sender, EventArgs e)
        {

            var myWebApi = HttpApiClient.Create<MyWebApi>();
            var userStr = myWebApi.Login(new User { UserName = txbUserName.Text, Password = txbPassword.Text }).GetAwaiter().GetResult();
            myWebApi.Dispose();
            MessageBox.Show(userStr);
        }
    }
    [HttpHost("http://127.0.0.1:5000")]

    public interface MyWebApi : IDisposable
    {
    
        [HttpPost("/authapi/login")]
        ITask<string> Login(User user);
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

}
