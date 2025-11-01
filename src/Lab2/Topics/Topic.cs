using Itmo.ObjectOrientedProgramming.Lab2.Messages;
using Itmo.ObjectOrientedProgramming.Lab2.Recipients;

namespace Itmo.ObjectOrientedProgramming.Lab2.Topics;

public class Topic
{
    public string Name { get; }

    public IReadOnlyCollection<IRecipient> Users { get; }

    public Topic(string name, IReadOnlyCollection<IRecipient> users)
    {
        Name = name;
        Users = users;
    }

    public void AddMessage(Message message)
    {
        foreach (IRecipient user in Users)
        {
            user.ReceiveMessage(message);
        }
    }
}