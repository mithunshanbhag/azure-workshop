using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace AzureWorkshop.CodeSamples.FunctionApps;

public static class HttpTriggerWebhookReceiver
{
    [FunctionName("HttpTriggerWebhookReceiver")] 
    public static async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)]
        HttpRequest req,
        ILogger log)
    {
        log.LogInformation($"C# HTTP trigger function received a request: {await req.ReadAsStringAsync()}");

        return new OkResult();
    }
}