var host = new HostBuilder()
    .ConfigureFunctionsWebApplication()
    // The next line is only needed for the SDK binding demo
    .ConfigureServices((hostContext, services) => 
        services.AddAzureClients(clientBuilder => 
            clientBuilder.AddBlobServiceClient(hostContext.Configuration["AzureWebJobsStorage"])))
    .Build();

host.Run();