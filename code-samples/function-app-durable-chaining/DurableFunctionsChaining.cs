using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace AzureWorkshop.CodeSamples.FunctionApps;

public static class DurableFunctionsChaining
{
    [FunctionName(nameof(OrchestratorClientFunction))]
    public static async Task<HttpResponseMessage> OrchestratorClientFunction(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get")]
        HttpRequestMessage req,
        [DurableClient] IDurableOrchestrationClient starter,
        ILogger log)
    {
        var instanceId = await starter.StartNewAsync(nameof(OrchestratorFunction));
        return starter.CreateCheckStatusResponse(req, instanceId);
    }

    [FunctionName(nameof(OrchestratorFunction))] // orchestration function
    public static async Task<int> OrchestratorFunction([OrchestrationTrigger] IDurableOrchestrationContext context)
    {
        var numbers = new[] {1, 2, 3, 4, 5};
        var squaresOfNumbers = await context.CallActivityAsync<int[]>(nameof(Square), numbers);
        var sumOfNumbers = await context.CallActivityAsync<int>(nameof(Sum), squaresOfNumbers);
        return sumOfNumbers;
    }

    [FunctionName(nameof(Square))] // mapper (activity function)
    public static IEnumerable<int> Square([ActivityTrigger] IDurableActivityContext context, ILogger log)
    {
        var numbers = context.GetInput<int[]>();
        return numbers.Select(num => num * num);
    }

    [FunctionName(nameof(Sum))] // reducer (activity function)
    public static int Sum([ActivityTrigger] IDurableActivityContext context, ILogger log)
    {
        var numbers = context.GetInput<int[]>();
        return numbers.Sum();
    }
}