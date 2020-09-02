# Prerequisites for labs

* Install JPTerm ([instructions](https://github.com/jmespath/jmespath.terminal))
* Install Azure CLI ([instructions](https://docs.microsoft.com/en-us/cli/azure/install-azure-cli?view=azure-cli-latest))
  * Log into Azure CLI with your Azure credentials: `az login`
  * Set the default azure subscription to use: `az account set -s <your-subscription-id>`
  * Create a resource group: `az group create -g azfunwkrg -l eastus2`
  * Set the resource group's name & location as the default: `az configure --default group=azfunwkrg location=eastus2 web=mithunshanbhag`
  * Set the following environment variables:
    * `export myRG=azfunwkrg`
    * `export myWebApp=mithunshanbhag`
  * Ensure all necessary env vars are set by running: `env | grep -i "my"`
* Install .NET Core 3.1 SDK ([instructions](https://dotnet.microsoft.com/download/dotnet-core/3.1))
* Install VSCode ([download](https://code.visualstudio.com/))
* Install the following VSCode Extensions:
  * Azure Account: [download link](https://marketplace.visualstudio.com/items?itemName=ms-vscode.azure-account) | `code --install-extension ms-vscode.azure-account`
  * Azure Tools: [download link](https://marketplace.visualstudio.com/items?itemName=ms-vscode.vscode-node-azure-pack) | `code --install-extension ms-vscode.vscode-node-azure-pack`
  * CSharp: [download link](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp) | `code --install-extension ms-dotnettools.csharp`
* @todo: Ensure that latest azure function tools are installed. 

Note: After each lab, please ensure that you delete the created resources (so as to not accrue costs).
