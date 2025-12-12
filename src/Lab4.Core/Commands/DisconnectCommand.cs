using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemApp;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

public class DisconnectCommand : ICommand
{
    public CommandExecutionResult Execute(IFileSystemApp fileSystemApp)
    {
        fileSystemApp.Disconnect();
        return new CommandExecutionResult.Succes();
    }
}