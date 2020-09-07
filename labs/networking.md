
# Labs: Virtual Machines

## #1: Open Port 80 for serving HTTP requests

* Create an Ubuntu VM using steps from [VM lab #1](./virtual-machines.md#1-create-an-ubuntu-vm-and-ssh-into-it).

* SSH into the VM and install NGINX server

    ```bash
    sudo apt-get -y update

    sudo apt-get -y install nginx

    exit
    ```

* See rules currently associated with VM's NIC's NSG.

    ```bash
    az network nsg list -o table

    az network nsg rule list --nsg-name <name-of-NSG>
    ```

* Add a rule to enable incoming traffic on port 80/http

    ```bash
    az network nsg rule create -n allow-https \
        --nsg-name <name-of-NSG> \
        --destination-port-ranges 443 \
        --priority 300
    ```

* Verify that the NGINX server is up and running by accessing `http://<public-ip-of-virtual-machine>`

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

* Note: This exercise will be done manually via portal (too many lengthy steps for CLI usage).

* Create a linux VM (please ensure that you've opened ports ports 80/http and 22/ssh). Ensure that this VM is in zone1 of a region's availability zone. 

* SSH into the machine to install nginx via apt-get package manager:

    ```bash
    sudo apt-get -y update

    sudo apt-get -y install nginx
    ```

* Create a linux VM (please ensure that you've opened ports ports 80/http and 3389/rdp). Ensure that this VM is in zone2 of a region's availability zone.

* RDP into the machine to install IIS via powershell:

    ```bash
    Install-WindowsFeature -name Web-Server -IncludeManagementTools
    ```

* Create and configure an azure load-balancer to use both VMs in a high-availability setting.

-----

## #4: [HomeWork] Load balanced VMs across Availability Sets (intra-regional HA)

-----

## #5: [HomeWork] Traffic Management across regions (inter-regional HA)

-----
