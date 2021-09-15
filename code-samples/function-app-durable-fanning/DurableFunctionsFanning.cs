using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace AzureFundamentalsWorkshop.CodeSamples.FunctionApps
{
    public static class DurableFunctionsFanning
    {
        [FunctionName("OrchestratorClientFunction")]
        public static async Task<HttpResponseMessage> HttpStart(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequestMessage req,
            [DurableClient] IDurableOrchestrationClient starter,
            ILogger log)
        {
            string instanceId = await starter.StartNewAsync("OrchestratorFunction", null);
            return starter.CreateCheckStatusResponse(req, instanceId);
        }

        [FunctionName("OrchestratorFunction")] // orchestration function
        public static async Task<string[]> RunOrchestrator(
            [OrchestrationTrigger] IDurableOrchestrationContext context)
        {
            var tokens = new string[] { "hello", "world", "welcome", "water", "air", "earth" };
            var reversedTokens = new string[tokens.Length];
            var tasks = new Task<string>[tokens.Length];
            for (int i = 0; i < tokens.Length; i++)
            {
                tasks[i] = context.CallActivityAsync<string>("Reverse", tokens[i]);
            }
            await Task.WhenAll(tasks);
            return tasks.Select(t => t.Result).ToArray();
        }

        [FunctionName("Reverse")] // activity function
        public static string Reverse([ActivityTrigger] IDurableActivityContext context, ILogger log)
        {
            var token = context.GetInput<string>();
            return string.Join("", token.ToArray().Reverse());
        }
    }
}