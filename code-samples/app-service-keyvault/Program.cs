using Azure.Extensions.AspNetCore.Configuration.Secrets;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;

namespace AzureFundamentalsWorkshop.CodeSamples.AppService;

public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args)
    {
        return Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((context, configurationBuilder) =>
            {
                var builtConfig = configurationBuilder.Build();

                var secretClient = new SecretClient(
                    new Uri(builtConfig["KeyVaultEndpoint"]),
                    new DefaultAzureCredential());

                configurationBuilder.AddAzureKeyVault(secretClient, new KeyVaultSecretManager());
            })
            .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}