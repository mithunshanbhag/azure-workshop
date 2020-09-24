using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace AzureFundamentalsWorkshop.CodeSamples.FunctionApps
{
    public static class HttpTriggerCSharp1
    {
        [FunctionName("HttpTriggerCSharp1")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            // note the app setting key must be of the format: @Microsoft.KeyVault(SecretUri=@replace-with-secret-uri)
            var val = Environment.GetEnvironmentVariable("@replace-with-app-setting", EnvironmentVariableTarget.Process);

            log.LogInformation($"The value is {val}.");
            return new OkObjectResult(val);
        }
    }
}
