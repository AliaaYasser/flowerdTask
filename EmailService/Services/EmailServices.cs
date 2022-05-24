
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Net.Mail;
using System.Text;

namespace EmailService.Services
{
    internal class EmailServices 
    {
        public EmailServices()=> SendEmail();
        private void SendingEmail(string email)
        {
            var to = "aliaayasser89@gmail.com";
            var from = "anyOne@gmail.com";
            MailMessage mailMessage = new(from,to);
            mailMessage.Body = email;
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.Credentials = new System.Net.NetworkCredential("Email@gmail", "Password");
            smtpClient.UseDefaultCredentials = true; 
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.EnableSsl = true;
            Console.WriteLine($"A product has added {mailMessage.ToString()}");
            smtpClient.Send(mailMessage);
           
        }

        public void SendEmail()
        {
            var factory = new ConnectionFactory
            {
                Uri = new Uri("amqp://guest:guest@localhost:5672/")
            };
            var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            channel.QueueDeclare("ProductsEx", true, false, false);
            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, eventArgs) =>
            {
                var body = eventArgs.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                SendingEmail(message);
            };
            channel.BasicConsume(queue: "ProductsEx", autoAck: true, consumer: consumer);

            Console.ReadKey();
        }
    }
}
