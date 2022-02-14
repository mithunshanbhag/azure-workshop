# Prerequisites for labs

* Please ensure that you have access to an active Azure subscription.
* Install Azure CLI ([instructions](https://docs.microsoft.com/en-us/cli/azure/install-azure-cli?view=azure-cli-latest))
  * Log into Azure CLI with your Azure credentials: `az login`
  * If your organization has MFA enabled, then you'll need to log into the Azure CLI as follows: `az login --tenant <your-tenant-id>`
  * Set the default azure subscription to use: `az account set -s <your-subscription-id>`
  * Create a resource group: `az group create -g azfunwkrg -l eastus2`
  * Set the resource group's name & location as the default: `az configure --default group=azfunwkrg location=eastus2 web=mithunshanbhag`
  * Set the following environment variables:
    * `export myRG=azfunwkrg`
    * `export myWebApp=mithunshanbhag`
  * Ensure all necessary env vars are set by running: `env | grep -i "my"`
* Install .NET Core 6 SDK ([instructions](https://dotnet.microsoft.com/download/dotnet/6.0))
* Install VSCode ([download](https://code.visualstudio.com/)) or Visual Studio ([download](https://visualstudio.microsoft.com/))
* If you're using VSCode, please install the following VSCode Extensions as well:
  * CSharp: [download link](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp) | `code --install-extension ms-dotnettools.csharp`
  * Azure Account: [download link](https://marketplace.visualstudio.com/items?itemName=ms-vscode.azure-account) | `code --install-extension ms-vscode.azure-account`
  * Azure Tools: [download link](https://marketplace.visualstudio.com/items?itemName=ms-vscode.vscode-node-azure-pack) | `code --install-extension ms-vscode.vscode-node-azure-pack`
  * ARM (Azure Resource Manager) Tools: [download link](https://marketplace.visualstudio.com/items?itemName=msazurermtools.azurerm-vscode-tools) | `code --install-extension msazurermtools.azurerm-vscode-tools`
* If you're using VSCode, please install the following tools as well:
  * Azurite Emulator (local storage emulator): [download link](https://docs.microsoft.com/en-us/azure/storage/common/storage-use-azurite?tabs=visual-studio)
* Install Azure CosmosDB Emulator: [instructions](https://docs.microsoft.com/en-us/azure/cosmos-db/local-emulator?tabs=ssl-netstd21#download-the-emulator)
* Install Azure Storage Explorer: [download link](https://azure.microsoft.com/en-in/features/storage-explorer/)
* Install Azure Functions Core Tools: [instructions](https://docs.microsoft.com/en-us/azure/azure-functions/functions-run-local?tabs=linux%2Ccsharp%2Cbash#v2)
* Install JPTerm ([instructions](https://github.com/jmespath/jmespath.terminal))

Note: After each lab, please ensure that you delete the created resources (so as to not accrue costs).
