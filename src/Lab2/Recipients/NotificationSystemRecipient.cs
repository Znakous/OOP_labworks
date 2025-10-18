using Itmo.ObjectOrientedProgramming.Lab2.Messages;
using Itmo.ObjectOrientedProgramming.Lab2.Notifiers;

namespace Itmo.ObjectOrientedProgramming.Lab2.Recipients;

public class NotificationSystemRecipient : IRecipient
{
    private readonly INotifier _notifier;

    private readonly IReadOnlyCollection<string> _banWords;

    public NotificationSystemRecipient(IReadOnlyCollection<string> banWords, INotifier notifier)
    {
        _banWords = banWords;
        _notifier = notifier;
    }

    public void ReceiveMessage(Message message)
    {
        foreach (string banWord in _banWords)
        {
            if (message.Body.Contains(banWord, StringComparison.OrdinalIgnoreCase)
                || message.Header.Contains(banWord, StringComparison.OrdinalIgnoreCase))
            {
                _notifier.Notify();
            }
        }
    }
}