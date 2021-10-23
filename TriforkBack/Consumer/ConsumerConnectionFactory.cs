using Consumer.Controllers;
using Consumer.DB;
using Consumer.Repository;
using Consumer.Repository.Timestamps;
using Consumer.Utility;
using RabbitMQ.Client;
using System;
using System.Text;

namespace Consumer
{
    class ConsumerConnectionFactory
    {
        public readonly ConnectionFactory connectionFactory;
        ConsumerConnectionFactory(string connectionString)
        {
            connectionFactory = new ConnectionFactory() { Uri = new Uri(connectionString) };
        }

        static void Main(string[] args)
        {
            var context = new TimestampContext();
            var timestampRepository = new TimestampRepository(context);
            var UOW = new UnitOfWork(context);

            const string queue = "logger";
            var consumer = new ConsumerConnectionFactory("amqp://guest:guest@localhost:5672");
            var consumerController = new ConsumerController(consumer.connectionFactory, queue);

            consumerController.SubscribeToTimeStampEvent((obj, eventArgs) =>
           {
               var body = eventArgs.Body.ToArray();
               var message = Encoding.UTF8.GetString(body);
               var dateTime = DateTime.Parse(message);

               if (TimestampUtility.TimeStampShouldSave(DateTime.Parse(message), DateTime.Now))
               {
                   try
                   {
                       timestampRepository.Add(new Timestamp(dateTime));
                       UOW.CompleteTransaction();
                   }
                   catch (Exception error)
                   {
                       Console.WriteLine(error.Message);
                   }

               }
               else
               {
                   try
                   {
                       if (TimestampUtility.TimeStampShouldPublish(DateTime.Parse(message)))
                           consumerController.PublishMessage(DateTime.Now.ToString());
                   }
                   catch (Exception error)
                   {
                       Console.WriteLine(error);
                   }

               }
           });

            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        }
    }
}
