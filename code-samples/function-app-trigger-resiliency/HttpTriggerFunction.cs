using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace AzureWorkshop.CodeSamples.FunctionApps;

public static class HttpTriggerFunction
{
    [FunctionName("HttpTriggerFunction")]
    //[FixedDelayRetry(5, "00:00:05")]
    //[ExponentialBackoffRetry(5, "00:00:05", "00:00:30")]
    public static IActionResult Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)]
        HttpRequest req,
        ILogger log)
    {
        log.LogInformation("C# HTTP trigger function processing a request.");

        throw new Exception("Intentionally thrown exception.");
    }
}