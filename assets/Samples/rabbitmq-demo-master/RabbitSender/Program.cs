using RabbitMQ.Client;
using System;
using System.Text;

namespace RabbitSender // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConnectionFactory factory = new();
            factory.Uri = new Uri("amqp://guest:guest@localhost:5672");
            factory.ClientProvidedName = "Rabbit Sender App";

            IConnection cnn = factory.CreateConnection();

            IModel channel = cnn.CreateModel();

            string exchangeName = "DemoExchange";
            string routingKey = "demo-routing-key";
            string queueName = "DemoQueue";

            channel.ExchangeDeclare(exchangeName, ExchangeType.Direct);
            channel.QueueDeclare(queueName, false, false, false, null);
            channel.QueueBind(queueName, exchangeName, routingKey, null);

            for (int i = 0; i < 60; i++)
            {
                Console.WriteLine($"sending message {i}");
                byte[] messagebodyBytes = Encoding.UTF8.GetBytes($"Message #{i}");
                channel.BasicPublish(exchangeName, routingKey, null, messagebodyBytes);
                Thread.Sleep(1000);
            }


            channel.Close();
            cnn.Close();
        }
    }
}