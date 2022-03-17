# SERVICE BUS

## #1: Posting messages to service bus queue

Create a console app which posts messages (text) to a service bus queue.

[[SOLUTION]](../code-samples/servicebus-queue-send/program.cs)

-----

## #2: Receiving messages from service bus queue

Create a console app which receives/dequeues messages from above service bus queue.

[[SOLUTION]](../code-samples/servicebus-queue-receive/program.cs)

-----

## #3: Publishing to service bus topic

Create a console app which posts messages (text) to a service bus topic.

[[SOLUTION]](../code-samples/servicebus-topic-send/program.cs)

-----

## #4: Subscribing to service bus topics

Create a console app which receives/dequeues messages from above service bus topic.

[[SOLUTION]](../code-samples/servicebus-topic-receive/program.cs)

-----

## #5: ServiceBus queue-triggered function

Create and deploy a function which uses a service bus queue trigger for receiving/processing messages.

[[SOLUTION]](../code-samples/function-app-servicebus-trigger/ServiceBusQueueTriggerFunction.cs)

-----

## #6: ServiceBus topic-triggered function

Create and deploy a function which uses service bus topic + subscription for receiving messages.

[[SOLUTION]](../code-samples/function-app-servicebus-trigger/ServiceBusSubscriptionTriggerFunction.cs)

-----

## #7: ServiceBus output binding (to queue)

Create and deploy a function which writes a message to a service bus queue every 30 seconds.

[[SOLUTION]](../code-samples/function-app-servicebus-output/ServiceBusQueueOutputFunction.cs)

-----

## #8: [HomeWork] ServiceBus output binding (to topic)

Create and deploy a function which writes a message to a service bus topic every 30 seconds.

-----

## #9: ServiceBus multiple outputs (using IAsyncCollector)

Create and deploy a function which writes multiple messages to a service bus queue every 30 seconds.

[[SOLUTION]](../code-samples/function-app-servicebus-output/ServiceBusQueueMultipleOutputFunction.cs)

-----
