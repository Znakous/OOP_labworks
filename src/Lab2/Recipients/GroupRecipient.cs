using Itmo.ObjectOrientedProgramming.Lab2.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab2.Recipients;

public class GroupRecipient : IRecipient
{
    private readonly IReadOnlyCollection<IRecipient> _recipients;

    public GroupRecipient(IReadOnlyCollection<IRecipient> recipients)
    {
        _recipients = recipients;
    }

    public void ReceiveMessage(Message message)
    {
        foreach (IRecipient recipient in _recipients)
        {
            recipient.ReceiveMessage(message);
        }
    }
}