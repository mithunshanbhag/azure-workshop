// Default URL for triggering event grid function in the local environment.
// http://localhost:7071/runtime/webhooks/EventGrid?functionName={functionname}
using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.EventGrid.Models;
using Microsoft.Azure.WebJobs.Extensions.EventGrid;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace function_app_eventgrid_trigger
{
    public static class EventGridTriggerFunction
    {
        [FunctionName("EventGridTriggerFunction")]
        public static void Run(
            [EventGridTrigger] EventGridEvent ev,
            ILogger log)
        {
            log.LogInformation($"Event Type: {ev.EventType}");
            log.LogInformation($"Event Subject: {ev.Subject}");
            log.LogInformation($"Event Data: {ev.Data.ToString()}");
        }
    }
}
