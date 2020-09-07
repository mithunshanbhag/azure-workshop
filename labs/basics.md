# Labs: Azure Basics

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

## #5: Pipe output value to external command

    ```bash
    az group list -o table | grep -i "azfunwkrg"
    ```

-----

## #6: Capture output value in variable

    ```bash
    myVar = $(az group list -o table | grep -i "azfunwkrg")
    echo $myVar
    ```

-----

## #7: Select a property from an object

    ```bash
    az account show --query "name"
    ```

-----

## #8: Select a nested property from an object

    ```bash
    az account show --query "user.name"
    ```

-----

## #9: Select an object from an array

    ```bash
    az resource list --query "[0]"
    ```

-----

## #10: Select multiple objects from an array (splicing)

    ```bash
    az resource list --query "[0:3]"
    ```

-----

## #11: Select multiple objects from an array that match a condition (filtering)

    ```bash
    # Note: filter conditions are case-sensitive
    az resource list --query "[?type=='Microsoft.Sql/servers'&&name=='mySqlServer1']"
    ```

-----

## #14: Select multiple objects from an array that match a condition (substring)

    ```bash
    az group list --query "[?contains(name, 'test')]"
    ```

-----

## #12: Select multiple properties (multi-select list)

    ```bash
    az resource list --query "[].[id, name]"
    ```

-----

## #13: Select multiple properties (multi-select hash)

    ```bash
    az resource list --query "[].{resourceId:id, resourceName:name}"
    ```

-----
