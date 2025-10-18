using Itmo.ObjectOrientedProgramming.Lab2.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab2.Recipients;

public class Group : IRecipient
{
    private readonly IReadOnlyCollection<IRecipient> _recipients;

    public Group(IReadOnlyCollection<IRecipient> recipients)
    {
        _recipients = recipients;
    }

    public void AddMessage(Message message)
    {
        foreach (IRecipient recipient in _recipients)
        {
            recipient.AddMessage(message);
        }
    }
}