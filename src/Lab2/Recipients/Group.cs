using Itmo.ObjectOrientedProgramming.Lab2.Messages;
using Itmo.ObjectOrientedProgramming.Lab2.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab2.ResultTypes.AddMessageErrors;

namespace Itmo.ObjectOrientedProgramming.Lab2.Recipients;

public class Group : IRecipient
{
    private readonly IReadOnlyCollection<IRecipient> _recipients;

    public Group(IReadOnlyCollection<IRecipient> recipients)
    {
        _recipients = recipients;
    }

    public AddMessageResult AddMessage(Message message)
    {
        var errors = new List<IMessageAddError>();
        foreach (IRecipient recipient in _recipients)
        {
            if (recipient.AddMessage(message) is AddMessageResult.Failure failure)
            {
                errors.Add(failure.Error);
            }
        }

        return errors.Count is 0
            ? new AddMessageResult.Success()
            : new AddMessageResult.Failure(new MultiMessageAddError(errors));
    }
}