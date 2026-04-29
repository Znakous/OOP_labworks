using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.FileCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.CommandBuilders.FileCommandBuilders;

public class FileDeleteCommandBuilder : ICommandBuilder
{
    private string? _address;

    public FileDeleteCommandBuilder WithAddress(string address)
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

        return new FileDeleteCommand(_address);
    }
}