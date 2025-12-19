using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.CommandBuilders;

public class ConnectCommandBuilder : ICommandBuilder
{
    private string? _address;

    private IFileSystem? _fileSystem;

    public ConnectCommandBuilder WithAddress(string address)
    {
        _address = address;
        return this;
    }

    public ConnectCommandBuilder WithFileSystem(IFileSystem fileSystem)
    {
        _fileSystem = fileSystem;
        return this;
    }

    public ICommand? Build()
    {
        if (_address is null || _fileSystem is null)
        {
            return null;
        }

        return new ConnectCommand(_address, _fileSystem);
    }
}