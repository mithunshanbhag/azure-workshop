using Azure.Messaging.ServiceBus;

namespace AzureWorkshop.CodeSamples.ServiceBus;

public class Program
{
    private readonly string _connectionString = "@replace-with-connection-string";
    private readonly string _queueName = "myqueue1";
    private readonly ServiceBusClient _serviceBusClient;
    private readonly ServiceBusProcessor _serviceBusProcessor;

    private Program()
    {
        _serviceBusClient = new ServiceBusClient(_connectionString);
        _serviceBusProcessor = _serviceBusClient.CreateProcessor(_queueName); // note: default receive mode is peek-lock
    }

    public async Task CloseConnectionAsync()
    {
        await _serviceBusProcessor.StopProcessingAsync();
        await _serviceBusProcessor.CloseAsync();
        await _serviceBusClient.DisposeAsync();
        Console.WriteLine("Client connection closed");
    }

    public async Task ReceiveMessagesAsync()
    {
        // Register the function that will process messages
        _serviceBusProcessor.ProcessMessageAsync += ProcessMessagesAsync;
        _serviceBusProcessor.ProcessErrorAsync += ProcessErrorsAsync;
        await _serviceBusProcessor.StartProcessingAsync();
    }

    private async Task ProcessMessagesAsync(ProcessMessageEventArgs args)
    {
        var message = args.Message;
        var messageText = message.Body.ToString();
        Console.WriteLine($"Received message: {messageText}, delivery count: {message.DeliveryCount}");

        /*
            Note: Un-commenting below line will cause message to be 'abandoned' immediately.
            Message delivery will be retried if max delivery count has not been exceeded.
        */
        // throw new Exception("thrown deliberately");

        /*
            Note: un-commenting below line will cause message to be 'abandoned' immediately.
            Message delivery will be retried if max delivery count has not been exceeded.
        */
        // await args.AbandonMessageAsync(message);

        /*
            Note: un-commenting below line will cause message to be 'deadlettered' immediately.
            Message delivery will NOT be retried (irrespective of whether the message delivery count 
            has been exceeded or not).
        */
        // await args.DeadLetterMessageAsync(message);

        /*
            Note: un-commenting below line will cause message to be marked 'completed' immediately.
            Technically this is not required since MessageHandlerOptions's 'autoComplete' is set to true by default.
        */
        await args.CompleteMessageAsync(message);
    }

    private Task ProcessErrorsAsync(ProcessErrorEventArgs args)
    {
        Console.WriteLine($"Received error: {args.Exception.Message}");
        return Task.CompletedTask;
    }


    private static async Task Main()
    {
        var p = new Program();
        await p.ReceiveMessagesAsync();

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
        await p.CloseConnectionAsync();
    }
}