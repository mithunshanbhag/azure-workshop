using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace AzureFundamentalsWorkshop.CodeSamples.FunctionApps
{
    public class TimerTriggerCSharp
    {
        private readonly HttpClient _client;
        private readonly IConfiguration _configuration;

        public TimerTriggerCSharp(HttpClient client, IConfiguration config)
        {
            this._client = client;
            this._configuration = config;
        }

        [FunctionName("TimerTriggerCSharp")]
        public async Task Run([TimerTrigger("0 */1 * * * *")] TimerInfo myTimer, ILogger log)
        {
            // var content = await this._client.GetStringAsync("https://www.cnn.com");
            // log.LogInformation(content);

            var val = this._configuration["mysecret1"];
            log.LogInformation($"mysecret1: {this._configuration["mysecret1"]}");


        }
    }
}
