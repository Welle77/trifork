using Consumer.DB;
using Consumer.Repository;
using Consumer.Repository.Timestamps;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Threading.Tasks;

namespace Consumer.Controllers
{
    public class ChannelFactory
    {
        public IModel Channel;

        public ChannelFactory(string connectionString)
        {
            var connectionFactory = new ConnectionFactory() { Uri = new Uri(connectionString) };
            Channel = connectionFactory.CreateConnection().CreateModel();

        }
    }
}
