using System.Text.Json;
using Azure.Messaging.ServiceBus;

namespace AzureWorkshop.CodeSamples.FunctionApps.EventStream.Implementations;

public abstract class ServiceBusEventStreamBase<TEvent> : IServiceBusEventStream<TEvent>
{
    private readonly ServiceBusClient _serviceBusClient;
    private readonly ServiceBusSender _serviceBusSender;

    protected ServiceBusEventStreamBase(ServiceBusClient serviceBusClient, string topicName)
    {
        _serviceBusClient = serviceBusClient;
        _serviceBusSender = _serviceBusClient.CreateSender(topicName);
    }

    public async Task PublishAsync(TEvent evt, CancellationToken cancellationToken = default)
    {
        var serializedEvent = JsonSerializer.Serialize(evt);

        var serviceBusMessage = new ServiceBusMessage(serializedEvent);

        await _serviceBusSender.SendMessageAsync(serviceBusMessage, cancellationToken);
    }
}