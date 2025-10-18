using Itmo.ObjectOrientedProgramming.Lab2.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab2.Recipients;

public class FilterProxy : IRecipient
{
    private readonly IRecipient _recipient;

    private readonly ImportanceLevel _importanceThreshold;

    public FilterProxy(IRecipient recipient, ImportanceLevel importanceThreshold)
    {
        _recipient = recipient;
        _importanceThreshold = importanceThreshold;
    }

    public void AddMessage(Message message)
    {
        if (message.Importance >= _importanceThreshold)
            _recipient.AddMessage(message);
    }
}