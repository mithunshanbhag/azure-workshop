using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;

namespace AzureFundamentalsWorkshop.CodeSamples.ServiceBus
{
    class Program : IDisposable
    {
        private readonly int numMessages = 5;
        private readonly string connectionString = "@todo-replace-with-connection-string";
        private readonly string queueName = "@todo-replace-with-queue-name";
        private readonly IQueueClient queueClient;

        Program()
        {
            queueClient = new QueueClient(connectionString, queueName);
        }

        public void Dispose()
        {
            if (this.queueClient != null)
            {
                this.queueClient.CloseAsync();
            }
        }

        public async Task SendMessagesAsync()
        {
            for (int i = 0; i < this.numMessages; i++)
            {
                var messageText = $"{Guid.NewGuid()} - {DateTime.Now.ToString()}";
                var messageBytes = Encoding.UTF8.GetBytes(messageText);
                var message = new Message(messageBytes);

                await this.queueClient.SendAsync(message);
                Console.WriteLine($"Sent message: {messageText}");
            }
        }

        public void ReceiveMessages()
        {
            var msgHandlerOptions = new MessageHandlerOptions((args) => Task.CompletedTask);

            // Register the function that will process messages
            this.queueClient.RegisterMessageHandler(ProcessMessagesAsync, msgHandlerOptions);
        }

        private async Task ProcessMessagesAsync(Message message, CancellationToken token)
        {
            var messageBytes = message.Body;
            var messageText = Encoding.UTF8.GetString(message.Body);
            Console.WriteLine($"Received message: {messageText}");

            // mark the message as 'processed'
            await this.queueClient.CompleteAsync(message.SystemProperties.LockToken);
        }

        static async Task Main(string[] args)
        {
            Program p = new Program();
            await p.SendMessagesAsync(); // uncomment this to send messages
            // p.ReceiveMessages(); // uncomment this to receive messages

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
