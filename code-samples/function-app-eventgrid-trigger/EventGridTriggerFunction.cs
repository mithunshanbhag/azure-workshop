// Default URL for triggering event grid function in the local environment.
// http://localhost:7071/runtime/webhooks/EventGrid?functionName={functionname}

using Azure.Messaging.EventGrid;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.EventGrid;
using Microsoft.Extensions.Logging;

namespace AzureWorkshop.CodeSamples.FunctionApps;

public static class EventGridTriggerFunction
{
    [FunctionName("EventGridTriggerFunction")]
    public static void Run(
        [EventGridTrigger] EventGridEvent ev,
        ILogger log)
    {
        log.LogInformation($"Event Type: {ev.EventType}");
        log.LogInformation($"Event Subject: {ev.Subject}");
        log.LogInformation($"Event Data: {ev.Data}");
    }
}