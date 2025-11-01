using Itmo.ObjectOrientedProgramming.Lab2.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab2.Recipients.Archivers;

public interface IArchiver
{
    void ReceiveMessage(Message message);
}