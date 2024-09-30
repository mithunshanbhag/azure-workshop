var host = new HostBuilder()
    .ConfigureFunctionsWebApplication()
    .Build();

host.Run();