using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Services.AppAuthentication;
using Microsoft.Extensions.Configuration.AzureKeyVault;
using Microsoft.Extensions.Configuration;

[assembly: FunctionsStartup(typeof(AzureFundamentalsWorkshop.CodeSamples.FunctionApps.Startup))]

namespace AzureFundamentalsWorkshop.CodeSamples.FunctionApps
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
        }

        public override void ConfigureAppConfiguration(IFunctionsConfigurationBuilder builder)
        {
            var azureServiceTokenProvider = new AzureServiceTokenProvider();

            var keyVaultClient = new KeyVaultClient(
                new KeyVaultClient.AuthenticationCallback(
                    azureServiceTokenProvider.KeyVaultTokenCallback));

            builder.ConfigurationBuilder
                .AddAzureKeyVault(
                    "@replace-with-key-vault-uri", // replace later as needed
                    keyVaultClient,
                    new DefaultKeyVaultSecretManager());
        }
    }
}