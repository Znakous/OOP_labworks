using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.CommandBuilders;

public class DisconnectCommandBuilder : ICommandBuilder
{
    public ICommand? Build()
    {
        return new DisconnectCommand();
    }
}