using Azure.Extensions.AspNetCore.Configuration.Secrets;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using AzureFundamentalsWorkshop.CodeSamples.FunctionApps;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

[assembly: FunctionsStartup(typeof(Startup))]

namespace AzureFundamentalsWorkshop.CodeSamples.FunctionApps;

public class Startup : FunctionsStartup
{
    public override void Configure(IFunctionsHostBuilder builder)
    {
    }

    public override void ConfigureAppConfiguration(IFunctionsConfigurationBuilder builder)
    {
        var builtConfig = builder.ConfigurationBuilder.Build();

        var secretClient = new SecretClient(
            new Uri(builtConfig["KeyVaultEndpoint"]),
            new DefaultAzureCredential());

        builder.ConfigurationBuilder.AddAzureKeyVault(secretClient, new KeyVaultSecretManager());
    }
}