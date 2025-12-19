using Itmo.ObjectOrientedProgramming.Lab4.Core.Errors;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemApps;
using Itmo.ObjectOrientedProgramming.Lab4.Core.PathParsingStrategies;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Paths;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.FileCommands;

public class FileRenameCommand : FileSystemCommandBase
{
    private readonly string _address;
    private readonly string _name;

    public FileRenameCommand(string address, string name)
    {
        _address = address;
        _name = name;
    }

    public override CommandExecutionResult ExecuteOnConnected(IFileSystemContext fileSystemContext)
    {
        IPath address = fileSystemContext.PathParser.ParsePath(
            _address,
            new RelativePriorityStrategy(fileSystemContext.CurrentPath, fileSystemContext.FileSystem));
        IPath targetPath = address.Renamed(_name);
        IFileSystem fileSystem = fileSystemContext.FileSystem;

        if (!fileSystem.Exists(address))
        {
            return new CommandExecutionResult.Failure(
                new PerformedOperationOnNonExistentFile("Tried to rename non-existent file"));
        }

        if (fileSystem.Exists(targetPath))
        {
            return new CommandExecutionResult.Failure(
                new ShadowedExistingFile("Tried to rename file into already existent file"));
        }

        fileSystem.MoveFile(address, targetPath);
        return new CommandExecutionResult.Success();
    }
}