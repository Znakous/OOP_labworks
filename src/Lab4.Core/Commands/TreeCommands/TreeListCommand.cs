using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemApp;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemObjectVisitors;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Outputs;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.TreeCommands;

public class TreeListCommand : ICommand
{
    private readonly IOutput _output;

    public TreeListCommand(IOutput output)
    {
        _output = output;
    }

    public CommandExecutionResult Execute(IFileSystemApp fileSystemApp)
    {
        var showVisitor = new ListVisitor(_output);
        GetIteratorResult getIteratorResult = fileSystemApp.FileSystem.GetIterator();
        if (getIteratorResult is GetIteratorResult.Success success)
        {
            success.Iterator.Current().Accept(showVisitor);
        }

        var failure = (GetIteratorResult.Failure)getIteratorResult;
        return new CommandExecutionResult.Failure(failure.Error);
    }
}