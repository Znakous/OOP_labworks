using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemContexts;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemObjectFactories;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemObjects;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemObjectVisitors;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Outputs;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.TreeCommands;

public class TreeListCommand : ICommand
{
    private readonly IOutput _output;

    private readonly int _depth;

    public TreeListCommand(IOutput output, int depth)
    {
        _output = output;
        _depth = depth;
    }

    public CommandExecutionResult Execute(IFileSystemContext fileSystemContext)
    {
        var showVisitor = new ListVisitor(_output, _depth);
        var factory = new DirectoryAwareFileSystemObjectFactory(fileSystemContext.FileSystem);
        IFileSystemObject currentObject = factory.Create(fileSystemContext.CurrentPath);
        return new CommandExecutionResult.Success();
    }
}