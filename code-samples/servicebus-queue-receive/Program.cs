using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;

namespace AzureFundamentalsWorkshop.CodeSamples.ServiceBus
{
    class Program
    {
        private readonly string connectionString = "@replace-with-connection-string";
        private readonly string queueName = "@replace-with-queue-name";
        private readonly IQueueClient queueClient;

        Program()
        {
            queueClient = new QueueClient(connectionString, queueName); // note: default receive mode is peek-lock
        }

        public async Task CloseConnectionAsync()
        {
            await this.queueClient.CloseAsync();
            Console.WriteLine($"Client connection closed");
        }

        public void ReceiveMessages()
        {
            // Note: By default MessageHandlerOptions's 'autocomplete' is true.
            var msgHandlerOptions = new MessageHandlerOptions((args) => Task.CompletedTask);

            // Register the function that will process messages
            this.queueClient.RegisterMessageHandler(ProcessMessagesAsync, msgHandlerOptions);
        }

        private async Task ProcessMessagesAsync(Message message, CancellationToken token)
        {
            var messageBytes = message.Body;
            var messageText = Encoding.UTF8.GetString(message.Body);
            Console.WriteLine($"Received message: {messageText}, delivery count: {message.SystemProperties.DeliveryCount}");

            /*
                Note: Un-commenting below line will cause message to be 'abandoned' immediately.
                Message delivery will be retried if max delivery count has not been exceeded.
            */
            // throw new Exception("thrown deliberately");

            /*
                Note: un-commenting below line will cause message to be 'abandoned' immediately.
                Message delivery will be retried if max delivery count has not been exceeded.
            */
            // await this.queueClient.AbandonAsync(message.SystemProperties.LockToken);

            /*
                Note: un-commenting below line will cause message to be 'deadlettered' immediately.
                Message delivery will NOT be retried (irrespective of whether the message delivery count 
                has been exceeded or not).
            */
            // await this.queueClient.DeadLetterAsync(message.SystemProperties.LockToken);

            /*
                Note: un-commenting below line will cause message to be marked 'completed' immediately.
                Technically this is not required since MessageHandlerOptions's 'autoComplete' is set to true by default.
            */
            // await this.queueClient.CompleteAsync(message.SystemProperties.LockToken);

            await Task.CompletedTask;
        }

        static async Task Main(string[] args)
        {
            Program p = new Program();
            p.ReceiveMessages();

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
            await p.CloseConnectionAsync();
        }
    }
}
