# Nuget Package Publishing

> Please ensure that you have installed all the [prerequisites related to nuget package publishing](../lab-prerequisites.md).

## #: Publish nuget package (dotnet CLI)

* Add a nuget.config file to your project, in the same folder as your .csproj or .sln file

    ```xml
    <?xml version="1.0" encoding="utf-8"?>
    <configuration>
    <packageSources>
        <clear />
        <add key="<FEED_NAME>" value="https://pkgs.dev.azure.com/<ORGANIZATION_NAME>/<PROJECT_NAME>/_packaging/<FEED_NAME>/nuget/v3/index.json" />
    </packageSources>
    </configuration>
    ```

* Now publish the package to the Azure Artifacts feed by running the following command in your project folder:

    ```bash
    dotnet nuget push --source <FEED_NAME> --api-key <ANY_STRING> <NUPKG_PACKAGE_PATH>
    ```

## #: Consume nuget package (manually)

* Add the Azure Artifacts feed to the list of nuget sources

    ```bash
    dotnet nuget add source -n <FEED_NAME> https://pkgs.dev.azure.com/<ORGANIZATION_NAME>/<PROJECT_NAME>/_packaging/<FEED_NAME>/nuget/v3/index.json
    ```

* In the consumer project, add a reference to the published nuget package

    ```bash
    dotnet add package nuget-producer --interactive
    ```

* Restore the nuget package dependencies

    ```bash
    dotnet restore --interactive
    ```

## #: Publish nuget package (automated)

@TODO

## #: Consume nuget package (automated)

@TODO
