using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace WorkerService;
public class Worker : BackgroundService
{ 
    private readonly string _hostname;
    private readonly string _username;
    private readonly string _password;
    private readonly string _virtualHost;
    private readonly string _queueName;
    private IConnection _connection;
    private IModel _channel;

    public Worker(string hostname, string username, string password, string virtualHost, string queueName)
    {
        _hostname = hostname;
        _username = username;
        _password = password;
        _virtualHost = virtualHost;
        _queueName = queueName;
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
        _channel = _connection.CreateModel();
        _channel.QueueDeclare(queue: _queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var consumer = new EventingBasicConsumer(_channel);
        consumer.Received += (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            Console.WriteLine($"Received message: {message}");
        };
        _channel.BasicConsume(queue: _queueName, autoAck: true, consumer: consumer);

        return Task.CompletedTask;
    }

    public override void Dispose()
    {
        _channel.Close();
        _connection.Close();
        base.Dispose();
    }
}
