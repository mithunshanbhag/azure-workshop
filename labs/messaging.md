# Labs: Messaging

## #1: Creating service bus queue (using Azure CLI)

* First create the service bus namespace:

    ```bash
    az servicebus namespace create -n <namespace-name> --sku standard
    ```

* Then create the queue within that namespace:

    ```bash
    az servicebus queue create --name <queue-name> --namespace-name <namespace-name>
    ```

* Fetch the primary connection string:

    ```bash
    az servicebus namespace authorization-rule keys list \
    --name RootManageSharedAccessKey \
    --namespace-name <namespace-name> \
    --query primaryConnectionString \
    --output tsv
    ```

-----

## #2: Posting messages to service bus queue

-----

## #3: Receiving messages from service bus queue

-----

## #4: Publishing to service bus topic

-----

## #5: Subscribing to service bus topics

-----
