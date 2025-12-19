using Itmo.ObjectOrientedProgramming.Lab4.Core.Errors;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemApps;
using Itmo.ObjectOrientedProgramming.Lab4.Core.PathParsers;
using Itmo.ObjectOrientedProgramming.Lab4.Core.PathParsingStrategies;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Paths;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes;
using Path = Itmo.ObjectOrientedProgramming.Lab4.Core.Paths.Path;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.FileCommands;

public class FileMoveCommand : FileSystemCommandBase
{
    private readonly string _sourcePath;
    private readonly string _destinationPath;

    public FileMoveCommand(string sourcePath, string destinationPath)
    {
        _sourcePath = sourcePath;
        _destinationPath = destinationPath;
    }

    public override CommandExecutionResult ExecuteOnConnected(IFileSystemContext fileSystemContext)
    {
        IFileSystem fileSystem = fileSystemContext.FileSystem;
        PathParser pathParser = fileSystemContext.PathParser;
        IPath sourcePath = pathParser.ParsePath(_sourcePath, new RelativePriorityStrategy(fileSystemContext.CurrentPath, fileSystem));
        IPath relationForDestination = (sourcePath is Path.AbsolutePath)
            ? fileSystemContext.ConnectionPath
            : fileSystemContext.CurrentPath;

        IPath destinationPath = pathParser.ParsePath(_destinationPath, new RelativeOnlyStrategy(relationForDestination));

        if (!fileSystem.Exists(sourcePath))
        {
            return new CommandExecutionResult.Failure(
                new PerformedOperationOnNonExistentFile("Tried to move non-existent file"));
        }

        if (fileSystem.Exists(destinationPath))
        {
            return new CommandExecutionResult.Failure(
                new ShadowedExistingFile("Tried to move into existent file"));
        }

        fileSystem.MoveFile(sourcePath, destinationPath);
        return new CommandExecutionResult.Success();
    }
}