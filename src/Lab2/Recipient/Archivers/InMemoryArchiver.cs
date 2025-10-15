using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Recipient.Archivers;

public class InMemoryArchiver : IArchiver
{
    public ICollection<Message> Messages { get; } = new List<Message>();

    public AddMessageResult AddMessage(Message message)
    {
        Messages.Add(message);
        return new AddMessageResult.Success();
    }
}