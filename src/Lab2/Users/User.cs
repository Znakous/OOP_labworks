using Itmo.ObjectOrientedProgramming.Lab2.Messages;
using Itmo.ObjectOrientedProgramming.Lab2.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab2.ResultTypes.ReadMessageErrors;

namespace Itmo.ObjectOrientedProgramming.Lab2.Users;

public class User
{
    public IDictionary<Message, MessageStatus> MessageStatus { get; } = new Dictionary<Message, MessageStatus>();

    public void ReceiveMessage(Message message)
    {
        MessageStatus[message] = Messages.MessageStatus.Unread;
    }

    public MessageReadResult ReadMessage(Message message)
    {
        if (!MessageStatus.ContainsKey(message))
        {
            return new MessageReadResult.Failure(new MessageDoesntExist("User tried to read a non-existent message"));
        }

        if (MessageStatus[message] == Messages.MessageStatus.Read)
        {
            return new MessageReadResult.Failure(new MessageAlreadyRead("User tried to read a message twice"));
        }

        MessageStatus[message] = Messages.MessageStatus.Read;
        return new MessageReadResult.Success();
    }
}