using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemApps;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Paths;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Paths.PathHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.FileCommands;

public class FileMoveCommand : ICommand
{
    private readonly string _sourcePath;
    private readonly string _destinationPath;

    public FileMoveCommand(string sourcePath, string destinationPath)
    {
        _sourcePath = sourcePath;
        _destinationPath = destinationPath;
    }

    public CommandExecutionResult Execute(IFileSystemApp fileSystemApp)
    {
        IFileSystem fileSystem = fileSystemApp.FileSystem;
        IPathHandler handler = fileSystem.GetPathHandler();
        IPath source = handler.ParsePath(_sourcePath);
        IPath destination = handler.ParsePath(_destinationPath);
        if (fileSystem.MoveFile(source, destination) is FileSystemInteractionResult.Failure failure)
        {
            return new CommandExecutionResult.Failure(failure.Error);
        }

        return new CommandExecutionResult.Succes();
    }
}