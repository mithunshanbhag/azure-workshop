# Labs: Blob Storage

## #1: Create a blob container and upload files (using Azure CLI)

* Create the storage account

    ```bash
    az storage account create -n <storage-account-name> --sku Standard_LRS
    ```

* Fetch the storage account key

    ```bash
    az storage account keys list -n <storage-account-name>
    ```

* Create a container within the storage account

    ```bash
    az storage container create -n <container-name> \
        --account-name <storage-account-name> \
        --account-key <storage-account-key> \
        --public-access blob
    ```

* Upload a local file to the container

    ```bash
    az storage blob upload -c <container-name> \
        -f <path-to-local-file> \
        -n <new-blob-name> \
        --account-name <storage-account-name> \
        --account-key <storage-account-key>
    ```

-----

## #2: Create containers and upload blobs (using .NET Core SDK)

[[SOLUTION]](../code-samples/blob-storage-basics)

-----

## #3: Create a SAS token (using .NET Core SDK)

@todo

-----

## #4: Deploy SPA to static blob storage

@todo

* Build and package the app

    ```bash
    dotnet build

    # ensure that key vault values are being read correctly when executed locally.
    dotnet run

    dotnet publish -o ./publish

    cd publish

    zip -r publish.zip .
    ```

-----
