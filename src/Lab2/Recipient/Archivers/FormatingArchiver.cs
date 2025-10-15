using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Formatters;
using Itmo.ObjectOrientedProgramming.Lab2.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Recipient.Archivers;

public class FormatingArchiver : IArchiver
{
    private readonly IFormatter _formatter;

    public FormatingArchiver(IFormatter formatter)
    {
        _formatter = formatter;
    }

    public AddMessageResult AddMessage(Message message)
    {
        _formatter.WriteHeader(message.Header);
        _formatter.WriteBody(message.Body);
        return new AddMessageResult.Success();
    }
}