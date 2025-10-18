using Itmo.ObjectOrientedProgramming.Lab2.Formatters;
using Itmo.ObjectOrientedProgramming.Lab2.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab2.Recipients.Archivers;

public class FormatingArchiver : IArchiver
{
    private readonly IFormatter _formatter;

    public FormatingArchiver(IFormatter formatter)
    {
        _formatter = formatter;
    }

    public void ReceiveMessage(Message message)
    {
        _formatter.WriteHeader(message.Header);
        _formatter.WriteBody(message.Body);
    }
}