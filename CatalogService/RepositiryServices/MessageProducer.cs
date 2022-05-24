
using CatalogService.Interfaces;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Text;

namespace CatalogService.RepositiryServices;
public class MessageProducer : IMessageProducer
{
    public void SendMessage<T>(T message)
    {
        var factory = new ConnectionFactory
        {
            Uri = new Uri("amqp://guest:guest@localhost:5672/")
        };
        var connection = factory.CreateConnection();
        using var channel = connection.CreateModel(); 
        channel.ExchangeDeclare("ProductsEx",ExchangeType.Fanout,true);
        var json = JsonConvert.SerializeObject(message);
        var body = Encoding.UTF8.GetBytes(json);
        channel.BasicPublish(exchange: "", routingKey: "ProductsEx", body: body);
        channel.Close();
        connection.Close();
    }
}