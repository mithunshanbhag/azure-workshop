namespace AzureWorkshop.CodeSamples.FunctionApps.EventStream.Interfaces;

public interface IServiceBusEventStream<TEvent>
{
    Task PublishAsync(TEvent evt, CancellationToken cancellationToken = default);
}