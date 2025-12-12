using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemApp;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

public interface ICommand
{
    CommandExecutionResult Execute(IFileSystemApp fileSystemApp);
}