using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemFactories;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.CommandBuilders;

public class ConnectCommandBuilder : ICommandBuilder
{
    private string? _address;

    private IFileSystemImplFactory? _factory;

    public ConnectCommandBuilder WithAddress(string address)
    {
        _address = address;
        return this;
    }

    public ConnectCommandBuilder WithFactory(IFileSystemImplFactory factory)
    {
        _factory = factory;
        return this;
    }

    public ICommand? Build()
    {
        if (_address is null || _factory is null)
        {
            return null;
        }

        return new ConnectCommand(_address, _factory);
    }
}