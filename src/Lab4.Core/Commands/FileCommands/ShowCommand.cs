using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemApp;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemObjectVisitors;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Outputs;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.FileCommands;

public class ShowCommand : ICommand
{
    private readonly IOutput _output;

    public ShowCommand(IOutput output)
    {
        _output = output;
    }

    public CommandExecutionResult Execute(IFileSystemApp fileSystemApp)
    {
        var showVisitor = new ShowVisitor(_output, fileSystemApp.FileSystem);
        GetIteratorResult getIteratorResult = fileSystemApp.FileSystem.GetIterator();
        if (getIteratorResult is GetIteratorResult.Success success)
        {
            success.Iterator.Current().Accept(showVisitor);
        }

        var failure = (GetIteratorResult.Failure)getIteratorResult;
        return new CommandExecutionResult.Failure(failure.Error);
    }
}