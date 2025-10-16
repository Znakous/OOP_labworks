using Itmo.ObjectOrientedProgramming.Lab2.Messages;
using Itmo.ObjectOrientedProgramming.Lab2.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Recipients.Archivers;

public class InMemoryArchiver : IArchiver
{
    public ICollection<Message> Messages { get; } = new List<Message>();

    public AddMessageResult AddMessage(Message message)
    {
        Messages.Add(message);
        return new AddMessageResult.Success();
    }
}