# Provisioning

## #1: Create and use an Azure service principal (automation account)

* Note: This exercise will be done manually via portal

-----

## #2: Deploy resources using an ARM template

* Use the Azure CLI to deploy an ARM template as follows:

    ```bash
    az deployment group create -n <new-deployment-name> \
        --resource-group <resource-group-name> \
        --template-file <path-to-template-file>
    ```

[solution](../code-samples/arm-template-vnet/azuredeploy.json)

-----

## #3: Deploy ARM template using a parameters file

* Use the Azure CLI to deploy an ARM template and its parameters file as follows:

    ```bash
    # note: don't forget the '@' symbol before the parameters file
    az deployment group create -n <new-deployment-name> \
        --resource-group <resource-group-name> \
        --template-file <path-to-template-file> \
        --parameters @<path-to-parameters-file>
    ```

[solution](../code-samples/arm-template-vnet/azuredeploy.json)

-----
