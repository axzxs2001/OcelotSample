using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ServiceControlPanel.Agent.Check;
using ServiceControlPanel.Agent.Service;

namespace ServiceControlPanel.Agent
{
    /// <summary>
    /// Agent,Check,Service Govern
    /// </summary>
    public class AgentGovern : ConsulHttpAPI
    {
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="baseAddress">Base Address</param>
        public AgentGovern(string baseAddress = "http://localhost:8500") : base(baseAddress)
        {
        }
        #region Agent

        /// <summary>
        /// List Members,This endpoint returns the members the agent sees in the cluster gossip pool. Due to the nature of gossip, this is eventually consistent: the results may differ by agent. The strongly consistent view of nodes is instead provided by /v1/catalog/nodes.
        /// </summary>
        /// <param name="listMembersParmeter">List Members Parmeter</param>
        /// <returns></returns>
        public Member[] ListMembers(ListMembersParmeter listMembersParmeter)
        {
            return Get<ListMembersParmeter, Member[]>("/agent/members", listMembersParmeter);
        }

        /// <summary>
        /// This endpoint returns the configuration and member information of the local agent. The Config element contains a subset of the configuration and its format will not change in a backwards incompatible way between releases. DebugConfig contains the full runtime configuration but its format is subject to change without notice or deprecation.
        /// </summary>
        /// <returns></returns>
        public ReadConfigurationResult ReadConfiguration()
        {
            return Get<ReadConfigurationResult>("/agent/self");
        }
        /// <summary>
        /// This endpoint instructs the agent to attempt to connect to a given address.
        /// </summary>
        /// <param name="joinAgentParmeter">Join Agent Parmeter</param>
        /// <returns></returns>    
        public bool JoinAgent(JoinAgentParmeter joinAgentParmeter)
        {
            return Put<JoinAgentParmeter, bool>($"/agent/join", joinAgentParmeter);
        }

        #endregion

        #region Check
        /// <summary>
        /// This endpoint returns all checks that are registered with the local agent. These checks were either provided through configuration files or added dynamically using the HTTP API.        It is important to note that the checks known by the agent may be different from those reported by the catalog.This is usually due to changes being made while there is no leader elected.The agent performs active anti-entropy, so in most situations everything will be in sync within a few seconds.
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, ListChecks> ListChecks()
        {
            return Get<Dictionary<string, ListChecks>>("/agent/checks");
        }
        /// <summary>
        /// This endpoint adds a new check to the local agent. Checks may be of script, HTTP, TCP, or TTL type. The agent is responsible for managing the status of the check and keeping the Catalog in sync.
        /// </summary>
        /// <param name="registerCheckParmeter">Register Check Parmeter</param>
        /// <returns></returns>    
        public bool RegisterCheck(RegisterCheckParmeter registerCheckParmeter)
        {
            return Put<RegisterCheckParmeter, bool>($"/agent/check/register", registerCheckParmeter);
        }
        /// <summary>
        /// This endpoint remove a check from the local agent. The agent will take care of deregistering the check from the catalog. If the check with the provided ID does not exist, no action is taken.
        /// </summary>
        /// <param name="checkID">Check ID</param>
        /// <returns></returns>    
        public bool DeregisterCheck(string checkID)
        {
            return Put<bool>($"/agent/check/deregister/{checkID}");
        }
        #endregion

        #region service
        /// <summary>
        /// This endpoint returns all the services that are registered with the local agent. These services were either provided through configuration files or added dynamically using the HTTP API.        It is important to note that the services known by the agent may be different from those reported by the catalog.This is usually due to changes being made while there is no leader elected.The agent performs active anti-entropy, so in most situations everything will be in sync within a few seconds.
        /// </summary>
        /// <returns></returns>    
        public Dictionary<string, ListService> ListServices()
        {
            return Get<Dictionary<string, ListService>>($"/agent/services");
        }

        /// <summary>
        /// This endpoint adds a new service, with an optional health check, to the local agent.        The agent is responsible for managing the status of its local services, and for sending updates about its local services to the servers to keep the global catalog in sync.
        /// </summary>
        /// <returns></returns>
        /// <param name="registerServiceParmeter">Register Service Parmeter</param>
        public bool RegisterServices(RegisterServiceParmeter registerServiceParmeter)
        {
            return Put<RegisterServiceParmeter, bool>($"/agent/service/register", registerServiceParmeter);
        }
        /// <summary>
        /// This endpoint removes a service from the local agent. If the service does not exist, no action is taken.The agent will take care of deregistering the service with the catalog.If there is an associated check, that is also deregistered.
        /// </summary>
        /// <returns></returns>
        /// <param name="deregisterCheckParmeter">Deregister Check Parmeter</param>
        public bool DeregisterServices(string serviceID)
        {
            return Put<bool>($"/agent/service/deregister/{serviceID}");
        }
        #endregion

    }
}
