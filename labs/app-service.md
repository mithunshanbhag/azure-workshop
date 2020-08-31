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

* Create a .Net Core 3.1 app as follows:

    ```bash
    mkdir $myWebApp && cd $myWebApp

    dotnet new webapp

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

## #3: Fetch configuration values from Azure Key Vault



-----
