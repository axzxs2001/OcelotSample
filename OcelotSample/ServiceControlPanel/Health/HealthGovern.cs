using ServiceControlPanel.Health;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ServiceControlPanel.Health
{
    /// <summary>
    /// Health Govern
    /// </summary>
    public class HealthGovern : ConsulHttpAPI
    {

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="baseAddress">Base Address</param>
        public HealthGovern(string baseAddress = "http://localhost:8500") : base(baseAddress)
        {
        }

        /// <summary>
        ///List Checks for Service,This endpoint returns the checks associated with the service provided on the path.
        /// </summary>
        /// <param name="checkServiceParmeter">Check Service Parmeter</param>
        /// <returns></returns>
        public BaseCheckNodeResult[] ListChecksForService(CheckServiceParmeter checkServiceParmeter)
        {
            return Get<CheckServiceParmeter, BaseCheckNodeResult[]>($"/health/checks/{checkServiceParmeter.Service}", checkServiceParmeter);
        }

        /// <summary>
        ///List Checks in State,This endpoint returns the checks in the state provided on the path.
        /// </summary>
        /// <param name="checkServiceParmeter">Check Service Parmeter</param>
        /// <returns></returns>
        public CheckNodeResult[] ListChecksInState(ListChecksInStateParmeter listChecksInStateParmeter)
        {
            return  Get<ListChecksInStateParmeter, CheckNodeResult[]>($"/health/state/{listChecksInStateParmeter.State}", listChecksInStateParmeter);
        }
    }
}
