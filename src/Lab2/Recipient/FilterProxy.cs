using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.ImportanceLevels;
using Itmo.ObjectOrientedProgramming.Lab2.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab2.ResultTypes.MessageAddErrors;

namespace Itmo.ObjectOrientedProgramming.Lab2.Recipient;

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
        if (message.ImportanceLevel < _importanceThreshold)
        {
            return new AddMessageResult.Failure(
                new ImportanceInsufficient("Importance threshold criteria not satisfied"));
        }

        return _recipient.AddMessage(message);
    }
}