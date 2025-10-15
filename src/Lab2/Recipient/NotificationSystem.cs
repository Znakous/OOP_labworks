using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Notifiers;
using Itmo.ObjectOrientedProgramming.Lab2.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab2.ResultTypes.MessageAddErrors;

namespace Itmo.ObjectOrientedProgramming.Lab2.Recipient;

public class NotificationSystem : IRecipient
{
    private readonly INotifier _notifier;

    private readonly IReadOnlyCollection<string> _banWords;

    public NotificationSystem(IReadOnlyCollection<string> banWords, INotifier notifier)
    {
        _banWords = banWords;
        _notifier = notifier;
    }

    public AddMessageResult AddMessage(Message message)
    {
        if (_banWords.Any(word => message.Contains(word)))
        {
            _notifier.Notify();
            return new AddMessageResult.Failure(new BannedWordInMessage("Met a banned word in message"));
        }

        return new AddMessageResult.Success();
    }

    public class NotificationSystemBuilder
    {
        private readonly INotifier _notifier;

        private readonly List<string> _banWords = [];

        public NotificationSystemBuilder(INotifier notifier)
        {
            _notifier = notifier;
        }

        public NotificationSystemBuilder WithBanWord(string banWord)
        {
            _banWords.Add(banWord);
            return this;
        }

        public NotificationSystem Build()
        {
            return new NotificationSystem(_banWords, _notifier);
        }
    }
}