using Itmo.ObjectOrientedProgramming.Lab2.Messages;
using Itmo.ObjectOrientedProgramming.Lab2.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab2.ResultTypes.ReadMessageErrors;

namespace Itmo.ObjectOrientedProgramming.Lab2.Users;

public class User
{
    private readonly Dictionary<Message, MessageStatus> _messageStatus = new Dictionary<Message, MessageStatus>();

    public void ReceiveMessage(Message message)
    {
        _messageStatus.TryAdd(message, Messages.MessageStatus.Unread);
    }

    public MessageReadResult ReadMessage(Message message)
    {
        if (!_messageStatus.ContainsKey(message))
        {
            return new MessageReadResult.Failure(new MessageDoesntExist("User tried to read a non-existent message"));
        }

        if (_messageStatus[message] == Messages.MessageStatus.Read)
        {
            return new MessageReadResult.Failure(new MessageAlreadyRead("User tried to read a message twice"));
        }

        _messageStatus[message] = Messages.MessageStatus.Read;
        return new MessageReadResult.Success();
    }

    public MessageStatus GetMessageStatus(Message message)
    {
        return _messageStatus[message];
    }

    public bool TryGetMessageStatus(Message message, out MessageStatus status)
    {
        return _messageStatus.TryGetValue(message, out status);
    }
}