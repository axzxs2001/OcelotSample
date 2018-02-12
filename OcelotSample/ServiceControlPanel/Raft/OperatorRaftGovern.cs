
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ServiceControlPanel.Raft
{
    /// <summary>
    /// Operator Raft Govern
    /// </summary>
    public class OperatorRaftGovern : ConsulHttpAPI
    {

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="baseAddress">Base Address</param>
        public OperatorRaftGovern(string baseAddress = "http://localhost:8500") : base(baseAddress)
        {
        }
        /// <summary>
        /// This endpoint reads the current raft configuration.
        /// </summary>
        /// <param name="readConfigurationParmeter">Read Configuration Parmeter</param>
        /// <returns></returns>
        public ReadConfigurationResult ReadConfiguration(ReadConfigurationParmeter  readConfigurationParmeter)
        {
            return Get< ReadConfigurationParmeter, ReadConfigurationResult>("/operator/raft/configuration", readConfigurationParmeter);
        }       
    }
}
