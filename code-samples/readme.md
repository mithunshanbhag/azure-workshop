# Notes for function app demos

* Don't forget to pull down the local.settings.json file (using the `Azure Functions: Download Remote Settings` command palette). Only the following properties are needed in the local.settings.json file:

    ```json
    {
        "IsEncrypted": false,
        "Values": {
            "AzureWebJobsStorage": "<@replace-with-actual-connection-string-of-storage-account>"
        }
    }
    ```

* Create a container named `mycontainer1` in the storage account associated with the function app. This is required for the blob storage trigger/input-binding demos to work.

* In the `host.json` explicitly mention the name of the functions that need to be executed.

* Ensure that the `AzureWebJobsServiceBus` application setting has the connection string of the service bus namespace. Ok to do it only in the `local.settings.json` file while debugging locally.
