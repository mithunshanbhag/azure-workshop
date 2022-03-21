using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace AzureWorkshop.CodeSamples.FunctionApps;

public static class DurableFunctionsFanning
{
    [FunctionName("OrchestratorClientFunction")]
    public static async Task<HttpResponseMessage> HttpStart(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get")]
        HttpRequestMessage req,
        [DurableClient] IDurableOrchestrationClient starter,
        ILogger log)
    {
        var instanceId = await starter.StartNewAsync("OrchestratorFunction");
        return starter.CreateCheckStatusResponse(req, instanceId);
    }

    [FunctionName("OrchestratorFunction")] // orchestration function
    public static async Task<string[]> RunOrchestrator(
        [OrchestrationTrigger] IDurableOrchestrationContext context)
    {
        var tokens = new[] {"hello", "world", "welcome", "water", "air", "earth"};
        var reversedTokens = new string[tokens.Length];
        var tasks = new Task<string>[tokens.Length];
        for (var i = 0; i < tokens.Length; i++) tasks[i] = context.CallActivityAsync<string>("Reverse", tokens[i]);
        return await Task.WhenAll(tasks);
    }

    [FunctionName("Reverse")] // activity function
    public static string Reverse([ActivityTrigger] IDurableActivityContext context, ILogger log)
    {
        var token = context.GetInput<string>();
        return string.Join("", token.ToArray().Reverse());
    }
}