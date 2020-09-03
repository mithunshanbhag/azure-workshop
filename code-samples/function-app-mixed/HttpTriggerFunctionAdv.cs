using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace AzureFundamentalsWorkshop.CodeSamples.FunctionApps
{
    public class WeatherRequest
    {
        public string City;
    }

    public class DailyWeather
    {
        public DateTime Date;
        public double celciusHigh;
        public double celciusLow;
    }

    public class WeatherResponse
    {
        public string City;
        public IEnumerable<DailyWeather> DailyReport;
    }

    public static class HttpTriggerFunctionAdv
    {
        [FunctionName("HttpTriggerFunctionAdv")]
        public static ActionResult Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] WeatherRequest request,
            ILogger log)
        {
            log.LogInformation($"C# HTTP trigger function received a request: {JsonConvert.SerializeObject(request)}");

            var response = new WeatherResponse
            {
                City = request.City,
                DailyReport = new List<DailyWeather>
                {
                    new DailyWeather { Date = DateTime.Today, celciusHigh = 40, celciusLow = 30 },
                    new DailyWeather { Date = DateTime.Today.AddDays(-1), celciusHigh = 39, celciusLow = 28 },
                    new DailyWeather { Date = DateTime.Today.AddDays(-2), celciusHigh = 38, celciusLow = 27 },
                    new DailyWeather { Date = DateTime.Today.AddDays(-3), celciusHigh = 37, celciusLow = 26 },
                    new DailyWeather { Date = DateTime.Today.AddDays(-4), celciusHigh = 36, celciusLow = 25 },
                    new DailyWeather { Date = DateTime.Today.AddDays(-5), celciusHigh = 35, celciusLow = 24 },
                    new DailyWeather { Date = DateTime.Today.AddDays(-6), celciusHigh = 34, celciusLow = 23 },
                },
            };

            return new OkObjectResult(response);
        }
    }
}
