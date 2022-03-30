using Azure.Messaging.ServiceBus;

namespace AzureWorkshop.CodeSamples.FunctionApps.EventStream.Implementations;

public class ContactEventStream : ServiceBusEventStreamBase<ContactEvent>, IContactEventStream
{
    public ContactEventStream(ServiceBusClient serviceBusClient) : base(serviceBusClient, ServiceBusConstants.ContactsTopicName)
    {
    }
}