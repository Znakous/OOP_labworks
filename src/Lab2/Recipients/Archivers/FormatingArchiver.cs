using Itmo.ObjectOrientedProgramming.Lab2.Messages;
using Itmo.ObjectOrientedProgramming.Lab2.Writers;

namespace Itmo.ObjectOrientedProgramming.Lab2.Recipients.Archivers;

public class FormatingArchiver : IArchiver
{
    private readonly IWriter _writer;

    public FormatingArchiver(IWriter writer)
    {
        _writer = writer;
    }

    public void AddMessage(Message message)
    {
        _writer.WriteHeader(message.Header);
        _writer.WriteBody(message.Body);
    }
}