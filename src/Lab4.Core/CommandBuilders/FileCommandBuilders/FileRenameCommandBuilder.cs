using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.FileCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.CommandBuilders.FileCommandBuilders;

public class FileRenameCommandBuilder : ICommandBuilder
{
    private string? _address;
    private string? _name;

    public FileRenameCommandBuilder WithAddress(string address)
    {
        _address = address;
        return this;
    }

    public FileRenameCommandBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public ICommand? Build()
    {
        if (_address is null || _name is null)
        {
            return null;
        }

        return new FileRenameCommand(_address, _name);
    }
}