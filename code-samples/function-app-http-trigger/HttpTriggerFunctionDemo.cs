using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AzureWorkshop.CodeSamples.FunctionApps;

public class HttpTriggerFunctionDemo(ILogger<HttpTriggerFunctionDemo> logger)
{
    [Function(nameof(HttpTriggerFunction))]
    public IActionResult HttpTriggerFunction(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")]
        HttpRequest req)
    {
        logger.LogInformation("C# HTTP trigger function processed a request.");
        return new OkObjectResult("Welcome to Azure Functions!");
    }
}