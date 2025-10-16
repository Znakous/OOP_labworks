using Itmo.ObjectOrientedProgramming.Lab2.Messages;
using Itmo.ObjectOrientedProgramming.Lab2.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Recipients;

public interface IRecipient
{
    AddMessageResult AddMessage(Message message);
}