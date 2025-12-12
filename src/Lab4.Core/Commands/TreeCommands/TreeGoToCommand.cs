using Itmo.ObjectOrientedProgramming.Lab4.Core.Errors;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemApp;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FIleSystemIterators;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Paths.PathHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.TreeCommands;

public class TreeGoToCommand : ICommand
{
    private readonly string _address;

    public TreeGoToCommand(string address)
    {
        _address = address;
    }

    public CommandExecutionResult Execute(IFileSystemApp fileSystemApp)
    {
        IFileSystem fileSystem = fileSystemApp.FileSystem;
        GetIteratorResult result = fileSystem.GetIterator();
        IPathHandler pathHandler = fileSystem.GetPathHandler();
        if (result is GetIteratorResult.Failure failure)
        {
            return new CommandExecutionResult.Failure(failure.Error);
        }

        IFileSystemIterator iterator = ((GetIteratorResult.Success)result).Iterator;
        if (!iterator.TryMoveTo(pathHandler.ParsePath(_address)))
        {
            return new CommandExecutionResult.Failure(
                new MovedToNonExistentPath("Called Tree Move To towards path that doesn't exist"));
        }

        return new CommandExecutionResult.Succes();
    }
}