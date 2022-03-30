namespace AzureWorkshop.CodeSamples.FunctionApps.EventStream.Interfaces;

public interface IContactEventStream: IServiceBusEventStream<ContactEvent>
{
}