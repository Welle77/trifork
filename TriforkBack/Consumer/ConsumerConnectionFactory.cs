using Consumer.Controllers;
using Consumer.DB;
using Consumer.Repository.Timestamps;
using System;

namespace Consumer
{
    class ConsumerConnectionFactory
    {
        static void Main(string[] args)
        {
            var context = new TimestampContext();
            var timestampRepository = new TimestampRepository(context);
            var UOW = new UnitOfWork(context);
            var channelFactory = new ChannelFactory("amqp://guest:guest@localhost:5672");
            var messageQueueProvider = new MessageQueueController(channelFactory.Channel, "logger", timestampRepository, UOW);


            messageQueueProvider.SubscribeToTimeStampEvent();

            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        }
    }
}
