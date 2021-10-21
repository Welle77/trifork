using Consumer.DB;
using Consumer.Repository;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Threading.Tasks;

namespace Consumer.Controllers
{
    class ConsumerController : BaseController
    {

        private readonly IModel Channel; 
        private readonly string Queue;
        public readonly EventingBasicConsumer EventingBasicConsumer;

        public ConsumerController(ConnectionFactory connectionFactory, string queue)
        {
            Queue = queue;
            Channel = connectionFactory.CreateConnection().CreateModel();
            Channel.QueueDeclare(queue: Queue, durable: true, exclusive: false, arguments: null);
            EventingBasicConsumer = new EventingBasicConsumer(Channel);
            Channel.BasicConsume(queue: Queue, autoAck: true, consumer: EventingBasicConsumer);

        }

        ~ConsumerController()
        {
            if (!Channel.IsClosed)
                Channel.Close();
        }

        public void SubscribeToTimeStampEvent(EventHandler<BasicDeliverEventArgs> eventCallback)
        {
            EventingBasicConsumer.Received += eventCallback;
        }

        public void PublishMessage(string message)
        {
            var body = Encoding.UTF8.GetBytes(message);
            Channel.BasicPublish(exchange: "", routingKey: Queue, body: body);
        }
    }
}
