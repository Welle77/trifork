using RabbitMQ.Client;
using System;
using System.Text;
using System.Threading;

namespace Producer
{
    class Producer
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { Uri = new Uri("amqp://guest:guest@localhost:5672") };
            using (IConnection connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "logger", durable: true, exclusive: false, arguments: null);
                    var props = channel.CreateBasicProperties();
                    props.Persistent = true;
                    while (true)
                    {
                        string message = DateTime.Now.ToString();
                        var body = Encoding.UTF8.GetBytes(message);
                        channel.BasicPublish(exchange: "", routingKey: "logger", props, body: body);
                        Thread.Sleep(1000);
                    }
                }
            }

        }
    }
}
