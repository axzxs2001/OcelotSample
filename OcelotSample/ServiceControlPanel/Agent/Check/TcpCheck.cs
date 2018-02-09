using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceControlPanel.Agent.Check
{
    public class TcpCheck : Check
    {
        public string Tcp
        { get; set; }

        public string Interval
        { get; set; }

        public string TimeOut
        { get; set; }
    }
}
