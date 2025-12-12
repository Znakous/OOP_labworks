using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemApp;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Paths;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Paths.PathHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.FileCommands;

public class FileRenameCommand : ICommand
{
    private readonly string _address;
    private readonly string _name;

    public FileRenameCommand(string address, string name)
    {
        _address = address;
        _name = name;
    }

    public CommandExecutionResult Execute(IFileSystemApp fileSystemApp)
    {
        IFileSystem fileSystem = fileSystemApp.FileSystem;
        IPathHandler handler = fileSystem.GetPathHandler();
        IPath address = handler.ParsePath(_address);
        if (fileSystem.RenameFile(address, _name) is FileSystemInteractionResult.Failure failure)
        {
            return new CommandExecutionResult.Failure(failure.Error);
        }

        return new CommandExecutionResult.Succes();
    }
}