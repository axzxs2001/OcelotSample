using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceControlPanel.Agent.Check
{
    /// <summary>
    /// script check
    /// </summary>
    public class ScriptCheck : Check
    {
        public string[] Args
        { get; set; }

        public string Interval
        { get; set; }

        public string TimeOut
        { get; set; }
    }
}
