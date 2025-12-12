using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemApp;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Paths;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

public class ConnectCommand : ICommand
{
    private readonly IPath _address;

    public ConnectCommand(IPath address)
    {
        _address = address;
    }

    public CommandExecutionResult Execute(IFileSystemApp fileSystemApp)
    {
        fileSystemApp.Connect(_address);
        return new CommandExecutionResult.Succes();
    }
}