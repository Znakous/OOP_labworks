using Itmo.ObjectOrientedProgramming.Lab2.Loggers;
using Itmo.ObjectOrientedProgramming.Lab2.Messages;
using Itmo.ObjectOrientedProgramming.Lab2.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Recipients;

public class LoggerProxy : IRecipient
{
    private readonly IRecipient _recipient;

    private readonly ILogger _logger;

    public LoggerProxy(IRecipient recipient, ILogger logger)
    {
        _recipient = recipient;
        _logger = logger;
    }

    public AddMessageResult AddMessage(Message message)
    {
        _logger.Log(message);
        return _recipient.AddMessage(message);
    }
}