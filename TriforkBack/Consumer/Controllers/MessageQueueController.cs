using Consumer.DB;
using Consumer.Repository.Timestamps;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace Consumer.Controllers
{
    public class MessageQueueController : BaseController
    {
        private readonly EventingBasicConsumer EventingBasicConsumer;
        private readonly ITimestampRepository TimestampRepository;
        private readonly IUnitOfWork UnitOfWork;
        private readonly MessageQueueSender MessageQueueSender;

        public MessageQueueController(IModel Channel, string Queue, ITimestampRepository timestampRepository, IUnitOfWork unitOfWork)
        {
            EventingBasicConsumer = new EventingBasicConsumer(Channel);
            Channel.BasicConsume(queue: Queue, autoAck: true, consumer: EventingBasicConsumer);
            TimestampRepository = timestampRepository;
            UnitOfWork = unitOfWork;
            MessageQueueSender = new MessageQueueSender(Channel, Queue);
        }

        public void SubscribeToTimeStampEvent()
        {

            EventingBasicConsumer.Received += (object obj, BasicDeliverEventArgs eventArgs) =>
            {
                var body = eventArgs.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                var dateTime = DateTime.Parse(message);

                try
                {
                    if (dateTime.Second % 2 == 0)
                    {
                        MessageQueueSender.PublishMessage(DateTime.Now.ToString());
                    }
                    else
                    {
                        TimestampRepository.Add(new Timestamp(dateTime));
                        UnitOfWork.CompleteTransaction();
                    }
                }

                catch (Exception error)
                {
                    Console.WriteLine(error.Message);
                }
            };
        }
    }
}
