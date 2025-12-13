using Itmo.ObjectOrientedProgramming.Lab4.Core.Errors;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemApps;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FIleSystemIterators;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemObjectVisitors;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Outputs;
using Itmo.ObjectOrientedProgramming.Lab4.Core.PathHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.FileCommands;

public class FileShowCommand : ICommand
{
    private readonly IOutput _output;

    private readonly string _address;

    public FileShowCommand(string address, IOutput output)
    {
        _output = output;
        _address = address;
    }

    public CommandExecutionResult Execute(IFileSystemApp fileSystemApp)
    {
        IFileSystem fileSystem = fileSystemApp.FileSystem;
        var showVisitor = new ShowVisitor(_output, fileSystem);
        GetIteratorResult getIteratorResult = fileSystem.GetIterator();
        IPathHandler pathHandler = fileSystemApp.FileSystem.GetPathHandler();
        if (getIteratorResult is GetIteratorResult.Success success)
        {
            IFileSystemIterator clone = success.Iterator.Clone();
            if (clone.TryMoveTo(pathHandler.ParsePath(_address)))
            {
                clone.Current().Accept(showVisitor);
            }
            else
            {
                return new CommandExecutionResult.Failure(
                    new MovedToNonExistentPath("FileShow was called on file that doesn't exist"));
            }
        }

        var failure = (GetIteratorResult.Failure)getIteratorResult;
        return new CommandExecutionResult.Failure(failure.Error);
    }
}