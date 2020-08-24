# Labs: Virtual Machines

## Prerequisites

Log into Azure CLI with your Azure credentials.

-----

## 1. Create an Ubuntu VM and SSH into it

* Type the following command in Azure CLI to create the Ubuntu VM.

    ```bash
    az vm create \
        -n <virtual-machine-name> \
        -g <resource-group-name> \
        -l centralindia \
        --image Canonical:UbuntuServer:18.04-LTS:latest \
        --generate-ssh-keys \
        --admin-username azureuser
    ```

* The output of the command will be as follows (please copy the `publicIpAddress` from your output):

    ```json
    {
        "fqdns": "",
        "id": "/subscriptions/<redacted>/resourceGroups/rgtempdeleteme/providers/Microsoft.Compute/virtualMachines/<virtual-machine-name>",
        "location": "centralindia",
        "macAddress": "<redacted>",
        "powerState": "VM running",
        "privateIpAddress": "10.0.0.5",
        "publicIpAddress": "<public-ip-of-virtual-machine>",
        "resourceGroup": "<resource-group-name>",
        "zones": ""
    }
    ```

* Connect to the VM as follows

    ```bash
    ssh azureuser@<public-ip-of-virtual-machine>
    ```

-----

## Create an Ubuntu VM with custom SSH keys
