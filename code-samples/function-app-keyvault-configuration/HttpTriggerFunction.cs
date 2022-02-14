using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace AzureFundamentalsWorkshop.CodeSamples.FunctionApps;

public class HttpTriggerFunction
{
    private readonly IConfiguration _configuration;

    private readonly ILogger<HttpTriggerFunction> _log;

    public HttpTriggerFunction(IConfiguration config, ILogger<HttpTriggerFunction> log)
    {
        _configuration = config;
        _log = log;
    }

    [FunctionName("HttpTriggerFunction")]
    public IActionResult Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)]
        HttpRequest req)
    {
        var secretName = "@replace-with-kv-secret-name"; // replace later as needed
        var secretValue = _configuration[secretName];

        _log.LogInformation($"The value of the key vault secret `{secretName}` is `{secretValue ?? "undefined"}`");
        return new OkObjectResult(secretValue);
    }
}