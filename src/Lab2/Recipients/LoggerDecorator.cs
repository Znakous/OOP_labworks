using Itmo.ObjectOrientedProgramming.Lab2.Loggers;
using Itmo.ObjectOrientedProgramming.Lab2.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab2.Recipients;

public class LoggerDecorator : IRecipient
{
    private readonly IRecipient _recipient;

    private readonly ILogger _logger;

    public LoggerDecorator(IRecipient recipient, ILogger logger)
    {
        _recipient = recipient;
        _logger = logger;
    }

    public void AddMessage(Message message)
    {
        _logger.Log(message.Header);
        _logger.Log(message.Body);
        _recipient.AddMessage(message);
    }
}