using Itmo.ObjectOrientedProgramming.Lab4.Core.Errors;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemApps;
using Itmo.ObjectOrientedProgramming.Lab4.Core.PathParsingStrategies;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Paths;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes;
using Path = Itmo.ObjectOrientedProgramming.Lab4.Core.Paths.Path;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

public abstract class FileSystemCommandBase : ICommand
{
    public CommandExecutionResult Execute(IFileSystemContext fileSystemContext)
    {
        if (fileSystemContext.FileSystem is DisconnectedFileSystem)
        {
            return new CommandExecutionResult.Failure(
                new DisconnectedSystemInteraction("Executed command on disconnected filesystem"));
        }

        return ExecuteOnConnected(fileSystemContext);
    }

    public abstract CommandExecutionResult ExecuteOnConnected(IFileSystemContext fileSystemContext);

    protected IPath GetRelativePath(string pathString, IFileSystemContext fileSystemContext)
    {
        IPath path = fileSystemContext.PathParser.ParsePath(
            pathString,
            new RelativePriorityStrategy(fileSystemContext.CurrentPath, fileSystemContext.FileSystem));
        if (path is Path.AbsolutePath)
        {
            return fileSystemContext.PathParser.ParsePath(
                pathString,
                new RelativeOnlyStrategy(fileSystemContext.ConnectionPath));
        }

        return path;
    }
}