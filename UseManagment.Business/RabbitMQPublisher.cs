using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

public class RabbitMQPublisher
{
    private readonly string _hostname;
    private readonly string _username;
    private readonly string _password;
    private readonly int _port;
    private readonly string _virtualHost;
    private readonly string _queueName;
    private IConnection _connection;

    public RabbitMQPublisher(IConfiguration configuration)
    {
        var RabbitMqConfig = configuration.GetSection("RabbitMq");
        _hostname = RabbitMqConfig["HostName"];
        _port = int.Parse(RabbitMqConfig["Port"]);
        _username = RabbitMqConfig["UserName"];
        _password = RabbitMqConfig["Password"];
        _virtualHost = RabbitMqConfig["VirtualHost"];
        _queueName = RabbitMqConfig["QueueName"];
        CreateConnection();
    }

    private void CreateConnection()
    {
        
        var factory = new ConnectionFactory()
        {
            HostName = _hostname,
            UserName = _username,
            Password = _password,
            VirtualHost = _virtualHost
        };
        _connection = factory.CreateConnection();
    }

    public void SendMessage<T>(T message)
    {
        if (_connection != null)
        {
            using var channel = _connection.CreateModel();
            channel.QueueDeclare(queue: _queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);

            var json = JsonSerializer.Serialize(message);
            var body = Encoding.UTF8.GetBytes(json);

            channel.BasicPublish(exchange: "", routingKey: _queueName, basicProperties: null, body: body);
        }
    }
}
