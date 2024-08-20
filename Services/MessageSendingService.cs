using RabbitMQ.Client;
using System.Text;

namespace Services
{
    public class MessageSendingService
    {
        public static void Send()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "testMessage",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var message = "Hello from Producer!";
                var body = Encoding.UTF8.GetBytes(message);
                channel.BasicPublish(exchange: "",
                                     routingKey: "testMessage",
                                     basicProperties: null,
                                     body: body);
                Console.WriteLine("Producer sent: {0}", message);
                Thread.Sleep(100);
            }
        }


    }
}
