﻿using Azure.Messaging.ServiceBus;

namespace AzureWorkshop.CodeSamples.ServiceBus;

public class Program
{
    private readonly string _connectionString = "@replace-with-connection-string";
    private readonly int _numMessages = 5; // arbitrary value
    private readonly ServiceBusClient _serviceBusClient;
    private readonly ServiceBusSender _serviceBusSender;
    private readonly string _topicName = "mytopic1";

    private Program()
    {
        _serviceBusClient = new ServiceBusClient(_connectionString);
        _serviceBusSender = _serviceBusClient.CreateSender(_topicName); // note: default receive mode is peek-lock
    }

    public async Task CloseConnectionAsync()
    {
        await _serviceBusSender.CloseAsync();
        await _serviceBusClient.DisposeAsync();
        Console.WriteLine("Client connection closed");
    }

    public async Task SendMessagesAsync()
    {
        for (var i = 0; i < _numMessages; i++)
        {
            var messageText = $"message# {i}";
            var message = new ServiceBusMessage(messageText);

            await _serviceBusSender.SendMessageAsync(message);
            Console.WriteLine($"Sent message: {messageText}");
        }
    }

    private static async Task Main(string[] args)
    {
        var p = new Program();
        await p.SendMessagesAsync();

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
        await p.CloseConnectionAsync();
    }
}