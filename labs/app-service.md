# Labs: App Service

## #1: Create an App Service (Linux)

* Create an app service plan (linux)

    ```bash
    az appservice plan create --sku B1 --is-linux -n <app-service-plan-name>
    ```

* Create an app service inside the above app service plan

    ```bash
    az webapp create -n $myWebApp \
        -p <app-service-plan-name> \
        --runtime "DOTNETCORE|3.1"
    ```

-----

## #2: Create and deploy a .NET Core app

* Create an app service (linux) using steps in lab #1 above.

* Configure app service for zip-push deployment

    ```bash
    az webapp config appsettings set --settings WEBSITE_RUN_FROM_PACKAGE="1"
    ```

* Create a .Net Core 3.1 Web API as follows:

    ```bash
    mkdir $myWebApp && cd $myWebApp

    dotnet new webapi

    dotnet build

    dotnet publish -o ./publish

    cd publish

    zip -r publish.zip .
    ```

* Deploy the publish package to app service

    ```bash
    az webapp deployment source config-zip -n $myWebApp --src publish.zip
    ```

* Browse to the deployed app service

    ```bash
    az webapp browse
    ```

-----

## #3: Create an Azure Key Vault for storing app configuration

* Create the Key Vault

    ```bash
    az keyvault create -n <key-vault-name>
    ```

* Create a secret (key-value pair) within the vault

    ```bash
    az keyvault secret set --name myCity --value Bangalore --vault-name <key-vault-name>
    ```

-----

## #4: Fetch configuration values from Azure Key Vault (@todo)

* Create a .Net Core 3.1 Web API as follows:

    ```bash
    mkdir $myWebApp && cd $myWebApp

    dotnet new webapi
    ```

* Add reference to the following nuget package:

    ```bash
    dotnet add package Microsoft.Extensions.Configuration.AzureKeyVault
    ```

* Modify all appsetting.json files to ensure that they contain the following key-value pairs (note: replace with correct key vault name later).

    ```json
    "KeyVaultEndpoint": "https://<keyvault-name>.vault.azure.net"
    ```

* Ensure that the `CreateHostBuilder` method in the app's Program.cs file is modified as follow to fetch key vault values on startup:

    ```csharp
    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((context, config) =>
            {
                var azureServiceTokenProvider = new AzureServiceTokenProvider();

                var keyVaultClient = new KeyVaultClient(
                    new KeyVaultClient.AuthenticationCallback(
                        azureServiceTokenProvider.KeyVaultTokenCallback));

                var builtConfig = config.Build();

                config.AddAzureKeyVault(
                    builtConfig["KeyVaultEndpoint"],
                    keyVaultClient,
                    new DefaultKeyVaultSecretManager());
            })
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
    ```

* Ensure that you add the following `using` statements:

    ```csharp
    using Microsoft.Azure.KeyVault;
    using Microsoft.Azure.Services.AppAuthentication;
    using Microsoft.Extensions.Configuration.AzureKeyVault;
    ```

* Use dependency injection to inject `IConfiguration` in the controller. Please ensure that you're `using Microsoft.Extensions.Configuration;`

* Ensure that `City` property is fetched from the key vault and returned in the response as follows:

    ```csharp
    City = _config["myCity"],
    ```

* Build and package the app

    ```bash
    dotnet build

    # ensure that key vault values are being read correctly when executed locally.
    dotnet run

    dotnet publish -o ./publish

    cd publish

    zip -r publish.zip .
    ```

* Assign a managed identity to the previously created app service

    ```bash
    az webapp identity assign
    ```

* Ensure that web app's identity has permissions to read key vault secrets

    ```bash
    az keyvault set-policy -n <key-vault-name> \
        --object-id <principalId-of-managed-identity> \
        --secret-permissions get list
    ```

* Deploy the publish package to app service

    ```bash
    az webapp deployment source config-zip -n $myWebApp --src publish.zip
    ```

* Browse to the deployed app service

    ```bash
    az webapp browse
    ```

-----
