
# Labs: Virtual Machines

## Resources

* [Azure Networking Documentation](https://docs.microsoft.com/en-us/azure/networking/networking-overview)
* [Azure VNET Documentation](https://docs.microsoft.com/en-us/azure/virtual-network/)

-----

## #1: Procure additional private IP for existing VM

* Create an Ubuntu VM using steps from [VM lab #1](./virtual-machines.md#1-create-an-ubuntu-vm-and-ssh-into-it).

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
