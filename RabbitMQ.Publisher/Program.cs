using RabbitMQ.Client;
using System.Text;

// baglantı olusturma 

ConnectionFactory connectionFactory = new();

connectionFactory.Uri = new("amqps://pntltxss:IMt0DR7p-3U2a7kzUjFVJCHEw9VttGiF@woodpecker.rmq.cloudamqp.com/pntltxss");

// bağlantıyı aktiflestirme ve kanal açma 

using IConnection connection = connectionFactory.CreateConnection();

using IModel channel = connection.CreateModel();

channel.ExchangeDeclare(exchange: "direct-exchange-example", type: ExchangeType.Direct);

//channel.BasicAck()
while (true)
{
    Console.Write("Mesaj  :  ");

    string message=Console.ReadLine();

    byte[] byteMessage=Encoding.UTF8.GetBytes(message);

    channel.BasicPublish(exchange: "direct-exchange-example", routingKey: "direct-queue-example", body: byteMessage);
}

//// Queue olusturma

//channel.QueueDeclare(queue: "examplequeue", exclusive: false,durable:true); // kuyrugun kalıcı olması için durable ozelligini aktif ettik.

//// Queue ya mesaj gonderme

//// RabbitMQ kuyruğa atacağı mesajları byte türünden kabul etmektedir.Haliyle mesajları bizim byte türüne dönüsturmemiz gerekecektir.Default exchange direct exchangedir.

////byte[] message=Encoding.UTF8.GetBytes("Merhaba");

////channel.BasicPublish(exchange: "", routingKey: "examplequeue", body: message);

//IBasicProperties basicProperties=channel.CreateBasicProperties();   // mesajların kalıcı olması için gereken konfigurasyon 

//basicProperties.Persistent = true;

//for (int i = 0; i < 100; i++)
//{
//    await Task.Delay(2000);

//    byte[] message = Encoding.UTF8.GetBytes("Merhaba" + i);

//    channel.BasicPublish(exchange: "", routingKey: "examplequeue", body: message,basicProperties:basicProperties);
//}



Console.Read();

