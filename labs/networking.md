
# Labs: Virtual Machines

## #1: Open Port 80 for serving HTTP requests

* Create an Ubuntu VM using steps from [VM lab #1](./virtual-machines.md#1-create-an-ubuntu-vm-and-ssh-into-it).

* SSH into the VM and install NGINX server

    ```bash
    sudo apt-get -y update

    sudo apt-get -y install nginx
    ```

* @todo

-----

## #2: Procure additional private IP for existing VM

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

## #3: Load balanced VMs across Availability Zones (intra-regional HA)

* This exercise will be done manually via portal (too many lengthy steps for CLI usage).

* Note: Ensure that you enable ports 80 (http) and 443 (https) as well as 22 (SSH) and 3389 (RDP).

* Note: Installing nginx via apt-get package manager on Linux:

    ```bash
    sudo apt-get -y update

    sudo apt-get -y install nginx
    ```

* Note: Installing IIS via powershell on Windows:

    ```bash
    Install-WindowsFeature -name Web-Server -IncludeManagementTools
    ```

## #4: [HomeWork] Load balanced VMs across Availability Sets (intra-regional HA)

-----

## #5: [HomeWork] Traffic Management across regions (inter-regional HA)

-----
