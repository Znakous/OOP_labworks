using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemContexts;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

public class DisconnectCommand : ICommand
{
    public CommandExecutionResult Execute(IFileSystemContext fileSystemContext)
    {
        fileSystemContext.FileSystem = new DisconnectedFileSystem();
        return new CommandExecutionResult.Success();
    }
}