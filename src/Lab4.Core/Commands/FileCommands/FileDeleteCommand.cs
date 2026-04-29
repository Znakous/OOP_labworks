using Itmo.ObjectOrientedProgramming.Lab4.Core.Errors;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemContexts;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Paths;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.FileCommands;

public class FileDeleteCommand : FileSystemCommandBase
{
    private readonly string _address;

    public FileDeleteCommand(string address)
    {
        _address = address;
    }

    public override CommandExecutionResult ExecuteOnConnected(IFileSystemContext fileSystemContext)
    {
        IPath address = GetRelativePath(_address, fileSystemContext);
        IFileSystem fileSystem = fileSystemContext.FileSystem;

        if (!fileSystem.Exists(address))
        {
            return new CommandExecutionResult.Failure(
                new PerformedOperationOnNonExistentFile("Tried to delete non-existent file"));
        }

        fileSystem.DeleteFile(address);
        return new CommandExecutionResult.Success();
    }
}