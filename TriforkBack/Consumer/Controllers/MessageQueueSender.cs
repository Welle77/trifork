using RabbitMQ.Client;
using System.Text;

namespace Consumer.Controllers
{
    public class MessageQueueSender
    {
        private readonly IModel Channel;
        private readonly string Queue;

        public MessageQueueSender(IModel channel, string queue)
        {
            Channel = channel;
            Queue = queue;
        }


        public void PublishMessage(string message)
        {
            Channel.QueueDeclare(queue: Queue, durable: true, exclusive: false, arguments: null);
            var body = Encoding.UTF8.GetBytes(message);
            Channel.BasicPublish(exchange: "", routingKey: Queue, body: body);
        }
    }
}
