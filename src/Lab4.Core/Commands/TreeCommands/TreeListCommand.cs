using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemApps;
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

    public CommandExecutionResult Execute(IFileSystemApp fileSystemApp)
    {
        var showVisitor = new ListVisitor(_output, _depth);
        GetIteratorResult getIteratorResult = fileSystemApp.FileSystem.GetIterator();
        if (getIteratorResult is GetIteratorResult.Success success)
        {
            success.Iterator.Current().Accept(showVisitor);
        }

        var failure = (GetIteratorResult.Failure)getIteratorResult;
        return new CommandExecutionResult.Failure(failure.Error);
    }
}