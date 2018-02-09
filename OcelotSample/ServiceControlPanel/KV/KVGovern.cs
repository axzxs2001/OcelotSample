using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ServiceControlPanel.KV
{
    /// <summary>
    /// KV Govern
    /// </summary>
    public class KVGovern : ConsulHttpAPI
    {
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="baseAddress">Base Address</param>
        public KVGovern(string baseAddress = "http://localhost:8500") : base(baseAddress)
        {
        }

        /// <summary>
        /// This endpoint returns the specified key. If no key exists at the given path, a 404 is returned instead of a 200 response.For multi-key reads, please consider using transaction.
        /// </summary>
        /// <param name="readKeyParmeter">Read Key Parmeter</param>
        /// <returns></returns>
        public ReadKeyResult[] ReadKey(ReadKeyParmeter readKeyParmeter)
        {

            return Get<ReadKeyParmeter, ReadKeyResult[]>($"/kv/{readKeyParmeter.Key}", readKeyParmeter);
        }

        /// <summary>
        /// Even though the return type is application/json, the value is either true or false, indicating whether the create/update succeeded.The table below shows this endpoint's support for blocking queries, consistency modes, and required ACLs.
        /// </summary>
        /// <param name="firEventParmeter">Create Update Key Parmeter</param>
        /// <param name="value">value</param>
        /// <returns></returns>
        public bool CreateUpdateKey(CreateUpdateKeyParmeter createUpdateKeyParmeter)
        {
            return Put<bool>($"/kv/{createUpdateKeyParmeter.Key}", createUpdateKeyParmeter.Value);
        }
        /// <summary>
        /// This endpoint deletes a single key or all keys sharing a prefix.
        /// </summary>
        /// <param name="deleteKeyParmeter">Delete Key Parmeter</param>
        /// <returns></returns>
        public bool DeleteKey(DeleteKeyParmeter deleteKeyParmeter)
        {
            return Delete<DeleteKeyParmeter, bool>($"/kv/{deleteKeyParmeter.Key}", deleteKeyParmeter);
        }
    }
}
