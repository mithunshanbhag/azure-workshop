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

Create a console app which posts messages (text) to a service bus queue.

[[SOLUTION]](../code-samples/servicebus-queue/program.cs)

-----

## #3: Receiving messages from service bus queue

Modify above console app to all receive/dequeue messages from above service bus queue.

[[SOLUTION]](../code-samples/servicebus-queue/program.cs)

-----

## #4: ServiceBus queue-triggered function

Create and deploy a function which uses a service bus queue trigger for receiving/processing messages.

[[SOLUTION]](../code-samples/function-app-servicebus-trigger/ServiceBusQueueTriggerFunction.cs)

-----

## #5: [Homework] Publishing to service bus topic

-----

## #6: [Homework] Subscribing to service bus topics

-----
