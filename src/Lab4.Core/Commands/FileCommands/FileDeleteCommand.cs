using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemApp;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Paths;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Paths.PathHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.FileCommands;

public class FileDeleteCommand : ICommand
{
    private readonly string _address;

    public FileDeleteCommand(string address)
    {
        _address = address;
    }

    public CommandExecutionResult Execute(IFileSystemApp fileSystemApp)
    {
        IFileSystem fileSystem = fileSystemApp.FileSystem;
        IPathHandler handler = fileSystem.GetPathHandler();
        IPath address = handler.ParsePath(_address);
        if (fileSystem.DeleteFile(address) is FileSystemInteractionResult.Failure failure)
        {
            return new CommandExecutionResult.Failure(failure.Error);
        }

        return new CommandExecutionResult.Succes();
    }
}