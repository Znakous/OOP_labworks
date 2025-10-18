using Itmo.ObjectOrientedProgramming.Lab2.Messages;
using Itmo.ObjectOrientedProgramming.Lab2.Recipients.Archivers;

namespace Itmo.ObjectOrientedProgramming.Lab2.Recipients;

public class ArchiverRecipient : IRecipient
{
    private readonly IArchiver _archiver;

    public ArchiverRecipient(IArchiver archiver)
    {
        _archiver = archiver;
    }

    public void AddMessage(Message message)
    {
        _archiver.AddMessage(message);
    }
}