using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.TreeCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.CommandBuilders.TreeCommandBuilders;

public class TreeGoToCommandBuilder : ICommandBuilder
{
    private string? _address;

    public TreeGoToCommandBuilder WithAddress(string address)
    {
        _address = address;
        return this;
    }

    public ICommand? Build()
    {
        if (_address is null)
        {
            return null;
        }

        return new TreeGoToCommand(_address);
    }
}