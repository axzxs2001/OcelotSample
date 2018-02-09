using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceControlPanel.Agent.Service
{
    /// <summary>
    /// list service
    /// </summary>
    public class ListService
    {
        /// <summary>
        /// id
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// service name
        /// </summary>
        public string Service { get; set; }
        /// <summary>
        /// service tags
        /// </summary>
        public string[] Tags { get; set; }
        /// <summary>
        /// port
        /// </summary>
        public int Port { get; set; }
        /// <summary>
        /// address
        /// </summary>
        public string Address { get; set; }
    }
}
