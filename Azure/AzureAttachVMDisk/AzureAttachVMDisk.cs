using System;
using System.Linq;
using System.Data;
using System.Net;
using System.Net.Http;
using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.Compute.Fluent;
using Microsoft.Rest.ClientRuntime;
using Microsoft.Rest.ClientRuntime.Azure;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Ayehu.Sdk.ActivityCreation
{
    public class AzureAttachVMDisk : IActivity
    {
        /// <summary>
        /// APPLICATION (CLIENT) ID
        /// </summary>
        public string appId;

        /// <summary>
        /// Directory (tenant) ID
        /// </summary>
        public string tenantId;

        /// <summary>
        /// Client secret
        /// </summary>
        /// <remarks>
        /// A secret string that the application uses to prove its identity when requesting a token. 
        /// Also can be referred to as application password.
        /// </remarks>
        public string secret;
        /// <summary>
        /// The azure portal subscription Id (Free Trial/Premium)
        /// </summary>
        public string subscriptionId;

        /// <summary>
        /// Virtual Machine name
        /// </summary>
        public string vmName;

        /// <summary>
        /// The new disk name
        /// </summary>
        public string diskName;

        public ICustomActivityResult Execute()
        {
            var azure = GetAzure();
            var vm = azure.VirtualMachines.List().Where(x => x.Name.ToLower() == vmName.ToLower()).FirstOrDefault();

            if (vm == null)
                throw new Exception(string.Format("The virtual machine {0} was not found", vmName));

            if (string.IsNullOrEmpty(diskName.Trim()))
                throw new Exception("The disk name can't be empty");

            var disk = azure.Disks.List().Where(d => d.Name.ToLower() == diskName.ToLower()).FirstOrDefault();

            if (disk == null)
                throw new Exception(string.Format("Disk '{0}' was not found.", diskName));

            vm.Update().WithExistingDataDisk(disk).Apply();
            return this.GenerateActivityResult(GetActivityResult);
        }

        private IAzure GetAzure()
        {
            var credentials = SdkContext.AzureCredentialsFactory.FromServicePrincipal(appId, secret, tenantId, AzureEnvironment.AzureGlobalCloud);
            var azure = Azure
                .Configure()
                .WithLogLevel(HttpLoggingDelegatingHandler.Level.Basic)
                .Authenticate(credentials)
                .WithSubscription(subscriptionId);

            return azure;
        }

        private DataTable GetActivityResult
        {
            get
            {
                DataTable dt = new DataTable("resultSet");
                dt.Columns.Add("Result");
                dt.Rows.Add("Success");

                return dt;
            }
        }
    }
}