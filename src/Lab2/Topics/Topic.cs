using Itmo.ObjectOrientedProgramming.Lab2.Messages;
using Itmo.ObjectOrientedProgramming.Lab2.Recipients;
using Itmo.ObjectOrientedProgramming.Lab2.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab2.ResultTypes.AddMessageErrors;

namespace Itmo.ObjectOrientedProgramming.Lab2.Topics;

public class Topic
{
    public string Name { get; }

    public IReadOnlyCollection<UserRecipient> Users { get; }

    public Topic(string name, IReadOnlyCollection<UserRecipient> users)
    {
        Name = name;
        Users = users;
    }

    public AddMessageResult AddMessage(Message message)
    {
        var errors = new List<IMessageAddError>();
        foreach (IRecipient user in Users)
        {
            if (user.AddMessage(message) is AddMessageResult.Failure failure)
            {
                errors.Add(failure.Error);
            }
        }

        return errors.Count is 0
            ? new AddMessageResult.Success()
            : new AddMessageResult.Failure(new MultiMessageAddError(errors));
    }
}