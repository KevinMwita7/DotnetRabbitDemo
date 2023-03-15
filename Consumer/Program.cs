using Consumer;
using Messaging;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>()
            .AddSingleton<IRabbitMQConnection, RabbitMQConnection>()
            .AddSingleton<IRabbitMQChannel, RabbitMQChannel>();
    })
    .Build();

// Initialize queues
QueueConfig.Init(host.Services.GetRequiredService<IRabbitMQChannel>().Model);

await host.RunAsync();
