using System.IO;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Services.AppAuthentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.AzureKeyVault;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(AzureFundamentalsWorkshop.CodeSamples.FunctionApps.Startup))]

namespace AzureFundamentalsWorkshop.CodeSamples.FunctionApps
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddHttpClient();

            // builder.Services.AddSingleton<IMyService>((s) => {
            //     return new MyService();
            // });
        }

        public override void ConfigureAppConfiguration(IFunctionsConfigurationBuilder builder)
        {
            var azureServiceTokenProvider = new AzureServiceTokenProvider();

            var keyVaultClient = new KeyVaultClient(
                new KeyVaultClient.AuthenticationCallback(
                    azureServiceTokenProvider.KeyVaultTokenCallback));

            builder.ConfigurationBuilder
                .AddAzureKeyVault(
                    "https://mithunkv12345.vault.azure.net/",
                    keyVaultClient,
                    new DefaultKeyVaultSecretManager());
        }
    }
}