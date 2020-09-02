# Notes

* Don't forget to pull down the local.settings.json file (using the `Azure Functions: Download Remote Settings` command palette). Only the following properties are needed in the local.settings.json file:

    ```json
    {
        "IsEncrypted": false,
        "Values": {
            "AzureWebJobsStorage": "<@todo-replace-with-actual-connection-string-of-storage-account>"
        }
    }
    ```

* Create a container named `mycontainer` in the storage account associated with the function app. This is required for the blob storage trigger/input-binding demos to work.

* In the `host.json` explicitly mention the name of the functions that need to be executed.
