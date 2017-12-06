using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace InfluxDBTool
{
    public partial class frmInfluxTool : Form
    {
        public frmInfluxTool()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //return;
            //var timestamp = DateTime.Now.ToUnixTimestamp();
            //List<string> list = new List<string>();
            //list.Add(string.Format("requestsQueued value={0} {1}", 20, timestamp));    //requestsQueued为指标的名称
            //list.Add(string.Format("currentConnections value={0} {1}", 10, timestamp));
            //list.Add(string.Format("bytesReceivedPerSec value={0} {1}", 100, timestamp));
            //string sql = string.Join("\n", list);
            //var result = client.Write("server01", sql);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            var client = new InfluxDBClient(tstbUrl.Text, tstbUserName.Text, tstbPassword.Text);
            var content = client.Query(tstbDataBase.Text, txbSQL.Text);
            var obj = JsonConvert.DeserializeObject(content) as JObject;

            txbQueryResult.Text = content;
            // GetValues(obj);
        }

        void GetValues(JToken obj)
        {


            switch (obj.Type)
            {
                case JTokenType.Property:
                    var pro = (obj as JProperty);
                    GetValues(pro.Value);
                    break;
                case JTokenType.Array:

                    foreach (var item in obj.Children())
                    {
                        GetValues(item);
                    }
                    break;
                case JTokenType.Object:
                    foreach (var item in obj.Children())
                    {
                        GetValues(item);
                    }
                    break;
                case JTokenType.String:
                    txbQueryResult.Text += "------String---------\r\n";
                    txbQueryResult.Text += obj.Path + ":" + obj.ToString() + "\r\n";
                    break;
            }

        }

        private void frmInfluxTool_Load(object sender, EventArgs e)
        {

        }
    }


}

