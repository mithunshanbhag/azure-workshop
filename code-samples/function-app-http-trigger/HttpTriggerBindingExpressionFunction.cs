using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AzureWorkshop.CodeSamples.FunctionApps;

public class HttpTriggerBindingExpressionFunctionDemo(ILogger<HttpTriggerBindingExpressionFunctionDemo> logger)
{
    [Function(nameof(HttpTriggerBindingExpressionFunction))]
    public IActionResult HttpTriggerBindingExpressionFunction(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "apiversion/{versionNum}")]
        HttpRequest req,
        string versionNum)
    {
        logger.LogInformation("C# HTTP trigger function processed a request.");

        var responseMessage = $"Received version number: {versionNum}";

        return new OkObjectResult(responseMessage);
    }
}