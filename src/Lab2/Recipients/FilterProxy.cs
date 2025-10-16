using Itmo.ObjectOrientedProgramming.Lab2.Messages;
using Itmo.ObjectOrientedProgramming.Lab2.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab2.ResultTypes.AddMessageErrors;

namespace Itmo.ObjectOrientedProgramming.Lab2.Recipients;

public class FilterProxy : IRecipient
{
    private readonly IRecipient _recipient;

    private readonly ImportanceLevel _importanceThreshold;

    public FilterProxy(IRecipient recipient, ImportanceLevel importanceThreshold)
    {
        _recipient = recipient;
        _importanceThreshold = importanceThreshold;
    }

    public AddMessageResult AddMessage(Message message)
    {
        if (message.Importance < _importanceThreshold)
        {
            return new AddMessageResult.Failure(
                new ImportanceInsufficient("Importance threshold criteria not satisfied"));
        }

        return _recipient.AddMessage(message);
    }
}