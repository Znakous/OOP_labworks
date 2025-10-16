using Itmo.ObjectOrientedProgramming.Lab2.Messages;
using Itmo.ObjectOrientedProgramming.Lab2.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab2.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.Recipients;

public class UserRecipient : IRecipient
{
    private readonly User _user;

    public UserRecipient(User user)
    {
        _user = user;
    }

    public AddMessageResult AddMessage(Message message)
    {
        _user.ReceiveMessage(message);
        return new AddMessageResult.Success();
    }
}