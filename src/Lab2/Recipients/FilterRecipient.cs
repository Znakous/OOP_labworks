using Itmo.ObjectOrientedProgramming.Lab2.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab2.Recipients;

public class FilterRecipient : IRecipient
{
    private readonly IRecipient _recipient;

    private readonly ImportanceLevel _importanceThreshold;

    public FilterRecipient(IRecipient recipient, ImportanceLevel importanceThreshold)
    {
        _recipient = recipient;
        _importanceThreshold = importanceThreshold;
    }

    public void ReceiveMessage(Message message)
    {
        if (message.Importance >= _importanceThreshold)
            _recipient.ReceiveMessage(message);
    }
}