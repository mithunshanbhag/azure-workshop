using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;

namespace AzureFundamentalsWorkshop.CodeSamples.ServiceBus
{
    class Program
    {
        private readonly int numMessages = 10; // arbitrary value
        private readonly string connectionString = "@replace-with-connection-string";
        private readonly string topicName = "@replace-with-queue-name";
        private readonly ITopicClient topicClient;

        Program()
        {
            topicClient = new TopicClient(connectionString, topicName); // note: default receive mode is peek-lock
        }

        public async Task CloseConnectionAsync()
        {
            await this.topicClient.CloseAsync();
            Console.WriteLine($"Client connection closed");
        }

        public async Task SendMessagesAsync()
        {
            for (int i = 0; i < this.numMessages; i++)
            {
                var messageText = $"message# {i}";
                var messageBytes = Encoding.UTF8.GetBytes(messageText);
                var message = new Message(messageBytes);

                await this.topicClient.SendAsync(message);
                Console.WriteLine($"Sent message: {messageText}");
            }
        }

        static async Task Main(string[] args)
        {
            Program p = new Program();
            await p.SendMessagesAsync();

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
            await p.CloseConnectionAsync();
        }
    }
}
