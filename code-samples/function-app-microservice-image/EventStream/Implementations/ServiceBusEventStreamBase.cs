namespace AzureWorkshop.CodeSamples.FunctionApps.EventStream.Implementations;

public abstract class ServiceBusEventStreamBase<TEvent> : IServiceBusEventStream<TEvent>
{
    public Task PublishAsync(TEvent evt, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}