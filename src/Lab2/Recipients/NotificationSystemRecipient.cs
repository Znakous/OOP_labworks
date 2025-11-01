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
        if (_banWords.Any(word => message.Body.Contains(word, StringComparison.InvariantCultureIgnoreCase))
            || _banWords.Any(word => message.Header.Contains(word, StringComparison.InvariantCultureIgnoreCase)))
        {
            _notifier.Notify();
        }
    }
}