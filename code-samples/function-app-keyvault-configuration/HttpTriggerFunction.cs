using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace AzureFundamentalsWorkshop.CodeSamples.FunctionApps
{
    public class HttpTriggerFunction
    {
        private readonly IConfiguration _configuration;

        private readonly ILogger<HttpTriggerFunction> _log;

        public HttpTriggerFunction(IConfiguration config, ILogger<HttpTriggerFunction> log)
        {
            this._configuration = config;
            this._log = log;
        }

        [FunctionName("HttpTriggerFunction")]
        public IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req)
        {
            var secretName = "@replace-with-kv-secret-name"; // replace later as needed
            var secretValue = this._configuration[secretName];

            this._log.LogInformation($"The value of the key vault secret `{secretName}` is `{secretValue ?? "undefined"}`");
            return new OkObjectResult(secretValue);
        }
    }
}
