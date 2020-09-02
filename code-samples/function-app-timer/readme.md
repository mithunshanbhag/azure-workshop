# Notes

* Don't forget to pull down the local.settings.json file (using the `Azure Functions` command palette).

* Only the following properties are needed in the local.settings.json file:

    ```json
    {
        "IsEncrypted": false,
        "Values": {
            "AzureWebJobsStorage": "<@todo-replace-with-actual-connection-string-of-storage-account>"
        }
    }
    ```
