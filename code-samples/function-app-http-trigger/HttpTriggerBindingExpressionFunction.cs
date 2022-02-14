using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace AzureFundamentalsWorkshop.CodeSamples.FunctionApps;

public static class HttpTriggerBindingExpressionFunction
{
    [FunctionName("HttpTriggerBindingExpressionFunction")]
    public static IActionResult Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "apiversion/{versionNum}")]
        HttpRequest req,
        string versionNum,
        ILogger log)
    {
        log.LogInformation("C# HTTP trigger function processed a request.");

        var responseMessage = $"Received version number: {versionNum}";

        return new OkObjectResult(responseMessage);
    }
}