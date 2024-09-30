using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StreamReader = System.IO.StreamReader;

namespace AzureWorkshop.CodeSamples.FunctionApps;

public class HttpTriggerFunctionContextDemo(ILogger<HttpTriggerFunctionContextDemo> logger)
{
    [Function("HttpTriggerFunctionContext")]
    public async Task<IActionResult> HttpTriggerFunctionContext(
        [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "{id:int}")]
        HttpRequest req,
        FunctionContext context)
    {
        logger.LogInformation($"Invocation ID: {context.InvocationId}");
        logger.LogInformation($"Function ID: {context.FunctionId}");

        logger.LogInformation($"Function Definition Name: {context.FunctionDefinition.Name}");
        logger.LogInformation($"Function Definition EntryPoint: {context.FunctionDefinition.EntryPoint}");
        logger.LogInformation($"Function Definition Id: {context.FunctionDefinition.Id}");
        logger.LogInformation($"Function Definition PathToAssembly: {context.FunctionDefinition.PathToAssembly}");

        logger.LogInformation("Function Definition Input Bindings:");
        foreach (var binding in context.FunctionDefinition.InputBindings) logger.LogInformation($" - {binding.Key} : [{binding.Value.Direction.ToString()}] {binding.Value.Type}");

        logger.LogInformation("Function Definition Output Bindings:");
        foreach (var binding in context.FunctionDefinition.OutputBindings) logger.LogInformation($" - {binding.Key} : [{binding.Value.Direction.ToString()}] {binding.Value.Type}");

        logger.LogInformation("Function Definition Parameters:");
        foreach (var parameter in context.FunctionDefinition.Parameters) logger.LogInformation($" - {parameter.Name} : {parameter.Type}");

        logger.LogInformation("Binding Context Data:");
        foreach (var kvp in context.BindingContext.BindingData) logger.LogInformation($" - {kvp.Key} : {kvp.Key}");

        var httpContext = context.GetHttpContext();
        logger.LogInformation("Http Context (Query parameters):");
        foreach (var queryParam in httpContext?.Request.Query!) logger.LogInformation($" - {queryParam.Key} : {queryParam.Value}");

        logger.LogInformation("Http Context (Headers):");
        foreach (var header in httpContext.Request.Headers!) logger.LogInformation($" - {header.Key} : {header.Value}");

        logger.LogInformation("Http Context (Route Values):");
        foreach (var routeValue in httpContext.Request.RouteValues!) logger.LogInformation($" - {routeValue.Key} : {routeValue.Value}");

        var reader = new StreamReader(req.Body);
        var requestBody = await reader.ReadToEndAsync();
        logger.LogInformation($"Request Body: {requestBody}");


        return new OkResult();
    }
}