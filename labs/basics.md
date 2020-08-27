# Labs: Azure Basics

## Resources

* [Azure Glossary](https://docs.microsoft.com/en-us/azure/azure-glossary-cloud-terminology)

-----

## #1: List your azure subscriptions

    ```bash
    az account show
    ```

-----

## #2: Set your active azure subscription

    ```bash
    az account set --subscription "my-subscription-id"
    ```

-----

## #3: List your resource groups

    ```bash
    az group list
    ```

-----

## #4: List your resources in tabular format

    ```bash
    az resource list -o table
    ```

-----

## Demos (using query filters & JP)
## #todo: Capture output value in variable

-----

## #@todo: Pipe output value to external command

-----

## #@todo: Select a property from an object

    ```bash
    az account show --query "name"
    ```

-----

## #@todo: Select a nested property from an object

    ```bash
    az account show --query "user.name"
    ```

-----

## #@todo: Select an object from an array

    ```bash
    az resource list --query "[0]"
    ```

-----

## #@todo: Select multiple objects from an array (splicing)

    ```bash
    az resource list --query "[0:3]"
    ```

-----

## #@todo: Select multiple objects from an array that match a condition (filtering)

    ```bash
    # Note: filter conditions are case-sensitive
    az resource list --query "[?type=='Microsoft.Sql/servers'&&name=='mySqlServer1']"
    ```

-----

## #@todo: Select multiple properties (multi-select list)

    ```bash
    az resource list --query "[].[id, name]"
    ```

-----

## #@todo: Select multiple properties (multi-select hash)

    ```bash
    az resource list --query "[].{resourceId:id, resourceName:name}"
    ```

-----
