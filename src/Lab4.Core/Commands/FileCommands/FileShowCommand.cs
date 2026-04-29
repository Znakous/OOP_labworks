using Itmo.ObjectOrientedProgramming.Lab4.Core.Errors;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemContexts;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Outputs;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Paths;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.FileCommands;

public class FileShowCommand : FileSystemCommandBase
{
    private readonly IOutput _output;

    private readonly string _address;

    public FileShowCommand(string address, IOutput output)
    {
        _output = output;
        _address = address;
    }

    public override CommandExecutionResult ExecuteOnConnected(IFileSystemContext fileSystemContext)
    {
        IPath address = GetRelativePath(_address, fileSystemContext);

        if (fileSystemContext.FileSystem.IsDirectory(address))
        {
            return new CommandExecutionResult.Failure(new DirectoryShowCall("Can't show content of directory"));
        }

        _output.Write(fileSystemContext.FileSystem.GetFileContent(address));
        return new CommandExecutionResult.Success();
    }
}