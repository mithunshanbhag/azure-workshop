# HIGH AVAILABILITY

## #1: Load balanced VMs across Availability Zones (intra-regional HA)

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

## #2: [HomeWork] Load balanced VMs across Availability Sets (intra-regional HA)

-----

## #3: [HomeWork] Traffic Management across regions (inter-regional HA)

-----
