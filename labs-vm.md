# Labs: Virtual Machines

## Prerequisites

Log into Azure CLI with your Azure credentials.

## Notes

After each lab, please ensure that you delete the created resources (so as to not accrue costs).

-----

## #1: Create an Ubuntu VM and SSH into it

* Type the following command in Azure CLI to create the Ubuntu VM.

    ```bash
    az vm create \
        -n <virtual-machine-name> \
        -g <resource-group-name> \
        -l centralindia \
        --image Canonical:UbuntuServer:18.04-LTS:latest \
        --admin-username azureuser \
        --generate-ssh-keys
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

* Connect to the VM.

    ```bash
    ssh azureuser@<public-ip-of-virtual-machine>
    ```

* Cleanup: After you're done, delete the Azure VM.

    ```bash
    az vm delete -n <virtual-machine-name> -g <resource-group-name>
    ```

-----

## #2: Create an Ubuntu VM with custom SSH keys

* Use the `ssh-keygen` utility to generate the SSH keys (both the public key `my_rsa.pub` and the private key `my_rsa` will be created in the current folder).

    ```bash
    ssh-keygen -t rsa -b 2048 -f ./my_rsa

    ls -la

    chmod 700 ./my_rsa
    ```

* Type the following command in Azure CLI to create the Ubuntu VM.

    ```bash
    az vm create \
        -n <virtual-machine-name> \
        -g <resource-group-name> \
        -l centralindia \
        --image Canonical:UbuntuServer:18.04-LTS:latest \
        --admin-username azureuser \
        --ssh-key-values ./my_rsa.pub
    ```

* Connect to the VM using the private SSH key.

    ```bash
    ssh -i ./my_rsa azureuser@<public-ip-of-virtual-machine>
    ```

-----

## #3: Fetch list of available VM images

* To fetch the list of most commonly used images:

    ```bash
    az vm image list -o table
    ```

* To fetch list of images by publisher (say `Canonical`).

    ```bash
    az vm image list-publishers -l centralindia --query "[?name=='Canonical']"

    az vm image list-offers -l centralindia -p Canonical

    az vm image list-skus -l centralindia -p Canonical -f UbuntuServer

    az vm image list -l centralindia -p Canonical -f ubuntuserver -s 18.04-LTS
    ```

-----
