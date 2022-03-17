# DEPLOYMENT

## #: Create a function app (using Azure CLI)

* First create a resource group.

    ```bash
    az group create --name <resource-group-name> --location eastus2
    ```

* Next, create an Azure storage account within the resource group

    ```bash
    az storage account create \
    --name <storage-account-name> \
    --location eastus2 \
    --resource-group <resource-group-name> \
    --sku Standard_LRS
    ```

* Finally, create the function app inside the resource group

    ```bash
    az functionapp create \
    --name <function-app-name> \
    --storage-account <storage-account-name> \
    --consumption-plan-location eastus2 \
    --resource-group <resource-group-name> \
    --os-type linux --runtime dotnet --functions-version 3
    ```

-----

## #: Deploy a function app (using Azure functions core tools)

* Create an Azure function app (linux) using steps in lab above

* Create a .Net 6 Timer-triggered function as follows

    ```bash
    mkdir <your-app-name> && cd <your-app-name>

    func init --worker-runtime dotnet

    func new -l C# -n TimerTriggerDemo -t TimerTrigger
    ```

* Modify the timer-trigger CRON expression as needed

* Finally, deploy the app

    ```bash
    func azure functionapp publish <function-app-name>
    ```

-----

## #: Deploy a function app (using Azure DevOps Pipeline)

* Create a service principal in Azure AD (via Azure Portal).

* Add the service principal to `contributor` role.

* Create a service connection in Azure DevOps using above service principal.

* Create a function app (using steps from lab above) and checkin to Azure Repos.

* Create a new YAML build pipeline via Azure DevOps portal.

* Add `dotnet build` task.

* Add `dotnet publish` task (ensure that `publishWebProjects` is set to false and `**/*.csproj` is specified as project path).

* Add `azure functions` task for deployment of above published package.

-----
