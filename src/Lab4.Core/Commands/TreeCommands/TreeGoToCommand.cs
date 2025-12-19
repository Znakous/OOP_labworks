using Itmo.ObjectOrientedProgramming.Lab4.Core.Errors;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemApps;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Paths;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.TreeCommands;

public class TreeGoToCommand : FileSystemCommandBase
{
    private readonly string _address;

    public TreeGoToCommand(string address)
    {
        _address = address;
    }

    public override CommandExecutionResult ExecuteOnConnected(IFileSystemContext fileSystemContext)
    {
        IPath path = GetRelativePath(_address, fileSystemContext);
        if (!fileSystemContext.FileSystem.Exists(path))
        {
            return new CommandExecutionResult.Failure(new NonExistentPathInteraction("Tried to go to non-existent path"));
        }

        fileSystemContext.CurrentPath = path;
        return new CommandExecutionResult.Success();
    }
}