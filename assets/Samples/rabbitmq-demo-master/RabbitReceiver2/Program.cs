using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace RabbitReceiver2 // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConnectionFactory factory = new();
            factory.Uri = new Uri("amqp://guest:guest@localhost:5672");
            factory.ClientProvidedName = "Rabbit Receiver2 App";

            IConnection cnn = factory.CreateConnection();

            IModel channel = cnn.CreateModel();

            string exchangeName = "DemoExchange";
            string routingKey = "demo-routing-key";
            string queueName = "DemoQueue";

            channel.ExchangeDeclare(exchangeName, ExchangeType.Direct);
            channel.QueueDeclare(queueName, false, false, false, null);
            channel.QueueBind(queueName, exchangeName, routingKey, null);
            channel.BasicQos(0, 1, false);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (sender, args) =>
            {
                Task.Delay(TimeSpan.FromSeconds(3)).Wait();

                var body = args.Body.ToArray();

                string message = Encoding.UTF8.GetString(body);

                Console.WriteLine($"message received {message}");

                channel.BasicAck(args.DeliveryTag, false);

            };

            string consumerTag = channel.BasicConsume(queueName, false, consumer);

            Console.ReadLine();

            channel.BasicCancel(consumerTag);

            channel.Close();
            cnn.Close();
        }
    }
}