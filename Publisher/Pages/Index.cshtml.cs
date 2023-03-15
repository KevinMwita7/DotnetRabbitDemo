using System.Threading.Channels;
using Messaging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Publisher.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly IRabbitMQChannel _channel;

    public IndexModel(ILogger<IndexModel> logger, IRabbitMQChannel channel)
    {
        _logger = logger;
        _channel = channel;
    }

    public void OnGet()
    {
        byte[] messageBodyBytes = System.Text.Encoding.UTF8.GetBytes("Hello, world!");
        _channel.BasicPublish(QueueConfig.Exchange, QueueConfig.RoutingKeyA, true, messageBodyBytes);
    }
}
