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

## #3: Using a SAS token (using .NET Core SDK)

[[SOLUTION]](../code-samples/blob-storage-sas)

-----

## #4: Deploy SPA to static blob storage

* Create a storage account and fetch its account key (see exercise #1 above).

* Enable static site hosting on the storage account
  
    ```bash
    az storage blob service-properties update --account-name <storage-account-name> \
        --account-key <storage-account-key> \
        --static-website \
        --404-document index.html \
        --index-document index.html
    ```

* Create a .Net Core 3.1 Blazor WASM app as follows:

    ```bash
    mkdir $myWebApp && cd $myWebApp

    dotnet new blazorwasm

    dotnet build

    # ensure that app is running correctly when executed locally.
    dotnet run

    dotnet publish -o ./publish
    ```

* Deploy the publish package to app service

    ```bash
    az storage blob upload-batch \
        -s ./publish/wwwroot \
        -d '$web' \
        --account-name <storage-account-name> \
        --account-key <storage-account-key>
    ```

* Fetch the endpoint URL and navigate to it in the browser

    ```bash
    az storage account show -n <storage-account-name> --query "primaryEndpoints.web" --output tsv
    ```

-----
