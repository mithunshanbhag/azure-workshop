using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FromBodyAttribute = Microsoft.Azure.Functions.Worker.Http.FromBodyAttribute;

namespace AzureWorkshop.CodeSamples.FunctionApps;

public class WeatherRequest
{
    public string City { get; set; }
}

public class DailyWeather
{
    public DateTime Date { get; set; }
    public double CelciusHigh { get; set; }
    public double CelciusLow { get; set; }
}

public class WeatherResponse
{
    public string City { get; set; }
    public IEnumerable<DailyWeather> DailyReport { get; set; }
}

public class HttpTriggerFunctionAdvDemo(ILogger<HttpTriggerFunctionAdvDemo> logger)
{
    [Function(nameof(HttpTriggerFunctionAdv1))]
    public ActionResult HttpTriggerFunctionAdv1(
        [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)]
        HttpRequest req,
        [FromBody] WeatherRequest request)
    {
        logger.LogInformation($"C# HTTP trigger function received a request: {JsonSerializer.Serialize(request)}");

        var response = GenerateWeatherResponse(request);

        return new OkObjectResult(response);
    }

   [Function(nameof(HttpTriggerFunctionAdv2))]
    public async Task<ActionResult> HttpTriggerFunctionAdv2(
        [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)]
        HttpRequest req)
    {
        var reader = new StreamReader(req.Body);
        var requestBody = await reader.ReadToEndAsync();
        var request = JsonSerializer.Deserialize<WeatherRequest>(requestBody);

        logger.LogInformation($"C# HTTP trigger function received a request: {JsonSerializer.Serialize(request)}");

        var response = GenerateWeatherResponse(request);

        return new OkObjectResult(response);
    }

    private static WeatherResponse GenerateWeatherResponse(WeatherRequest request)
    {
        return new WeatherResponse
        {
            City = request.City,
            DailyReport = new List<DailyWeather>
            {
                new() {Date = DateTime.Today, CelciusHigh = 40, CelciusLow = 30},
                new() {Date = DateTime.Today.AddDays(-1), CelciusHigh = 39, CelciusLow = 28},
                new() {Date = DateTime.Today.AddDays(-2), CelciusHigh = 38, CelciusLow = 27},
                new() {Date = DateTime.Today.AddDays(-3), CelciusHigh = 37, CelciusLow = 26},
                new() {Date = DateTime.Today.AddDays(-4), CelciusHigh = 36, CelciusLow = 25},
                new() {Date = DateTime.Today.AddDays(-5), CelciusHigh = 35, CelciusLow = 24},
                new() {Date = DateTime.Today.AddDays(-6), CelciusHigh = 34, CelciusLow = 23}
            }
        };
    }

}