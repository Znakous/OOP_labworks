using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.FileCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemContexts;
using Itmo.ObjectOrientedProgramming.Lab4.Core.PathBuildingStrategies;
using Itmo.ObjectOrientedProgramming.Lab4.Core.PathParsers;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation;

public class Program
{
    public static void Main(string[] args)
    {
        var mockSystem = new LocalFileSystem(new UnixPathBuildingStrategy());

        var app = new FileSystemContext(new PathParser(new UnixPathBuildingStrategy()));
        var connect = new ConnectCommand("/Users/znack.vladislav/Desktop/pythonchik", mockSystem);
        var copy = new FileCopyCommand("chup.py", "abuba");

        CommandExecutionResult executionResult = connect.Execute(app);
        if (executionResult is CommandExecutionResult.Failure executionFailure)
        {
            Console.WriteLine(executionFailure.Error.Message);
        }

        CommandExecutionResult executionResult1 = copy.Execute(app);
        if (executionResult1 is CommandExecutionResult.Failure executionFailure1)
        {
            Console.WriteLine(executionFailure1.Error.Message);
        }
    }
}