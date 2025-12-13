using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemApps;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemFactories;
using Itmo.ObjectOrientedProgramming.Lab4.Core.PathHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

public class ConnectCommand : ICommand
{
    private readonly string _address;

    private readonly IFileSystemImplFactory _factory;

    public ConnectCommand(string address, IFileSystemImplFactory factory)
    {
        _address = address;
        _factory = factory;
    }

    public CommandExecutionResult Execute(IFileSystemApp fileSystemApp)
    {
        IFileSystem fileSystem = fileSystemApp.FileSystem;
        IPathHandler handler = fileSystem.GetPathHandler();
        fileSystemApp.Connect(handler.ParsePath(_address), _factory);
        return new CommandExecutionResult.Succes();
    }
}