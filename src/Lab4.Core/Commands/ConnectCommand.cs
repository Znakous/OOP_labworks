using Itmo.ObjectOrientedProgramming.Lab4.Core.Errors;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemContexts;
using Itmo.ObjectOrientedProgramming.Lab4.Core.PathParsingStrategies;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Paths;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

public class ConnectCommand : ICommand
{
    private readonly string _address;

    private readonly IFileSystem _fileSystem;

    public ConnectCommand(string address, IFileSystem fileSystem)
    {
        _address = address;
        _fileSystem = fileSystem;
    }

    public CommandExecutionResult Execute(IFileSystemContext fileSystemContext)
    {
        IPath path = fileSystemContext.PathParser.ParsePath(_address, new AbsoluteOnlyStrategy());
        if (_fileSystem.Exists(path))
        {
            fileSystemContext.FileSystem = _fileSystem;
            fileSystemContext.ConnectionPath = path;
            fileSystemContext.CurrentPath = path;
            return new CommandExecutionResult.Success();
        }

        return new CommandExecutionResult.Failure(new NonExistentPathInteraction("Tried to connect to a non-existent root"));
    }
}