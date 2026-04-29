using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.FileCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Outputs;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.CommandBuilders.FileCommandBuilders;

public class FileShowCommandBuilder : ICommandBuilder
{
    private string? _address;

    private IOutput? _output;

    public FileShowCommandBuilder WithAddress(string address)
    {
        _address = address;
        return this;
    }

    public FileShowCommandBuilder WithOutput(IOutput output)
    {
        _output = output;
        return this;
    }

    public ICommand? Build()
    {
        if (_address is null || _output is null)
        {
            return null;
        }

        return new FileShowCommand(_address, _output);
    }
}