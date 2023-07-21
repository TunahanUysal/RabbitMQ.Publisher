using RabbitMQ.Client;
using System.Text;

// baglantı olusturma 

ConnectionFactory connectionFactory = new();

connectionFactory.Uri = new("amqpuri");

// baglantıyı aktiflestirme ve kanal açma 

using IConnection connection = connectionFactory.CreateConnection();

using IModel channel = connection.CreateModel();

// Queue olusturma

channel.QueueDeclare(queue: "examplequeue", exclusive: false);

// Queue ya mesaj gonderme

// RabbitMQ kuyruğa atacağı mesajları byte türünden kabul etmektedir.Haliyle mesajları bizim byte türüne dönüsturmemiz gerekecektir.Default exchange direct exchangedir.

//byte[] message=Encoding.UTF8.GetBytes("Merhaba");

//channel.BasicPublish(exchange: "", routingKey: "examplequeue", body: message);

for (int i = 0; i < 100; i++)
{
    await Task.Delay(2000);

    byte[] message = Encoding.UTF8.GetBytes("Merhaba" + i);

    channel.BasicPublish(exchange: "", routingKey: "examplequeue", body: message);
}



Console.Read();