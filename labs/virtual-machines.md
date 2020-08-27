# Labs: Virtual Machines

## Prerequisites

* Log into Azure CLI with your Azure credentials.

## Notes

* After each lab, please ensure that you delete the created resources (so as to not accrue costs).

## Resources

* Azure VM Documentation: [Windows](https://docs.microsoft.com/en-us/azure/virtual-machines/windows/) | [Linux](https://docs.microsoft.com/en-us/azure/virtual-machines/linux/)

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

## #4: Attach an additional data disk to a VM

* Create an Ubuntu VM using steps from lab #1 above.

* Create an empty managed disk (ensure that it's in the same region as the VM).

    ```bash
    az disk create -n <new-disk-name> \
        -g <resource-group-name> \
        -l centralindia \
        --size-gb 10 --sku Standard_LRS
    ```

* Attach the newly created disk to the existing VM

    ```bash
    az vm disk attach -n <new-disk-name> \
        -g <resource-group-name> \
        --vm-name <virtual-machine-name>
    ```

* For the data disk to be usable, it has to be mounted from the VM.

    ```bash
    ssh azureuser@<public-ip-of-virtual-machine>

    # see existing disks by running the 'df' command
    df

    # partition the disk with the 'parted' command
    sudo parted /dev/sdc --script mklabel gpt mkpart xfspart xfs 0% 100%

    # write a file system to the partition by using 'mkfs' command
    sudo mkfs.xfs /dev/sdc1

    # use 'partprobe' command to make the OS aware of the change
    sudo partprobe /dev/sdc1

    # mount the new disk so that it is accessible in the operating system.
    sudo mkdir /datadrive && sudo mount /dev/sdc1 /datadrive

    # run 'df' command again to verify if mounted
    df

    # navigate to the mounted device
    cd /datadrive

    # note: to ensure that the drive is remounted after a reboot, it must be
    # added to the '/etc/fstab' file.
    ```

-----

## #5: Procure additional private IP for existing VM

* Create an Ubuntu VM using steps from lab #1 above.

* Note the details associated with the VM's existing NIC (virtual network, subnets and private IP addresses).

    ```bash
    az vm nic list -g <resource-group-name> --vm-name <virtual-machine-name>

    az vm nic show -g <resource-group-name> --vm-name <virtual-machine-name> --nic <existing-NIC-name>
    ```

* Create a new NIC

    ```bash
    az network nic create -n <new-NIC-name> \
        -l centralindia \
        -g <resource-group-name> \
        --vnet-name <virtual-network-name> \
        --subnet <subnet-name>
    ```

* Stop-deallocate the VM

    ```bash
    az vm deallocate -n <virtual-machine-name> -g <resource-group-name>
    ```

* Attach the new NIC to the existing VM

    ```bash
    az vm nic add --vm-name <virtual-machine-name> \
        -g <resource-group-name> \
        --nics <new-NIC-name>
    ```

* Restart the VM

    ```bash
    az vm start -n <virtual-machine-name> -g <resource-group-name>
    ```

* Note the updated details private IP addresses associated with the VM

    ```bash
    az vm nic list -g <resource-group-name> --vm-name <virtual-machine-name>

    az vm nic show -g <resource-group-name> --vm-name <virtual-machine-name> --nic <existing-NIC-name>

    az vm nic show -g <resource-group-name> --vm-name <virtual-machine-name> --nic <new-NIC-name>
    ```

-----

## #6: (@todo) Procure additional public IP for existing VM

* Create an Ubuntu VM using steps from lab #1 above.

* Note the details associated with the VM's existing NIC (virtual network, subnets and private IP addresses).

    ```bash
    az vm nic list -g <resource-group-name> --vm-name <virtual-machine-name>

    az vm nic show -g <resource-group-name> --vm-name <virtual-machine-name> --nic <existing-NIC-name>
    ```
