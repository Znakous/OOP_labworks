using Itmo.ObjectOrientedProgramming.Lab2.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab2.Recipients.Archivers;

public class InMemoryArchiver : IArchiver
{
    private readonly List<Message> _messages;

    public InMemoryArchiver()
    {
        _messages = new List<Message>();
    }

    public void AddMessage(Message message)
    {
        _messages.Add(message);
    }
}