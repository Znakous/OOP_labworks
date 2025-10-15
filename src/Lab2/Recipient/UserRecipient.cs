using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Recipient;

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