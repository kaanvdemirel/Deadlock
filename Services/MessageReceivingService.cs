using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace Services
{
    class MessageReceivingService
    {
        public static void Receive()
        {
            var factory = new ConnectionFactory(){HostName="localhost"};
            using( var connection=factory.CreateConnection())
            using( var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "testMessage",
                    durable: false,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null);



                var consumer = new EventingBasicConsumer(channel);

                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    Console.WriteLine("Consumer received:{0}",message);
                    Thread.Sleep(5000);
                };

                channel.BasicConsume(queue: "testMessage",
                    autoAck: true, consumer: consumer);

                Console.WriteLine("Consumer is waiting for messages.");
                Console.ReadLine();
            }

        }



    }
}
