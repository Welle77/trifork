using Consumer.Controllers;
using Consumer.DB;
using Consumer.Repository;
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
            var timestampRepository = new TimestampRepository(new TimestampContext());
            var consumer = new ConsumerConnectionFactory("amqp://guest:guest@localhost:5672");
            const string queue = "logger";
            var consumerController = new ConsumerController(consumer.connectionFactory, queue);
            var timestampDBHandler = new TimestampDBHandler(timestampRepository);

            consumerController.SubscribeToTimeStampEvent(async (obj, e) =>
            {
                var body = e.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine("Recieved Timestamp: {0}", message);
                var dateTime = DateTime.Parse(message);

                if (TimestampUtility.TimeStampShouldSave(DateTime.Parse(message), DateTime.Now))
                {
                    await timestampDBHandler.AddTimeStampAsync(new Timestamp(dateTime));
                }
                else
                {
                    if (TimestampUtility.TimeStampShouldPublish(dateTime, DateTime.Now))
                        consumerController.PublishMessage(DateTime.Now.ToString());
                }
            });

            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        }
    }
}
