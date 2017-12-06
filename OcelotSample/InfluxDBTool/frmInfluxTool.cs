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
            var client = new InfluxDBClient("http://127.0.0.1:8086", "admin", "123456");
            txbQueryResult.Text = client.Query("AppMetricsDemo", txbSQL.Text);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
