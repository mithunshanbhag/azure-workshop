﻿using System.Reflection;
using Azure.Extensions.AspNetCore.Configuration.Secrets;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using AzureWorkshop.CodeSamples.FunctionApps;
using AzureWorkshop.CodeSamples.FunctionApps.Models;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(Startup))]

namespace AzureWorkshop.CodeSamples.FunctionApps;

public class Startup : FunctionsStartup
{
    public override void Configure(IFunctionsHostBuilder builder)
    {
        var configuration = builder.GetContext().Configuration;

        // injecting the cosmosdb client
        var cosmosAccountConnectionString = configuration[KeyVaultSecretNameConstants.CosmosAccountConnectionString];
        builder.Services.AddSingleton(provider => new CosmosClient(cosmosAccountConnectionString).GetDatabase(CosmosConstants.DatabaseName));

        // injecting auto-mapper
        builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

        // inject the services
        builder.Services
            .AddScoped<IContactService, ContactService>();

        // inject the repositories
        builder.Services
            .AddScoped<IContactRepository, ContactRepository>();

        // inject mediatr
        builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
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