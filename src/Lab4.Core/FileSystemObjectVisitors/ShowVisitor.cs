using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemObjects;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Outputs;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemObjectVisitors;

public class ShowVisitor : IFileSystemObjectVisitor
{
    private readonly IOutput _output;

    private readonly IFileSystem _fileSystem;

    public ShowVisitor(IOutput output, IFileSystem fileSystem)
    {
        _output = output;
        _fileSystem = fileSystem;
    }

    public bool Visit(DirectoryObject directory)
    {
        return false;
    }

    public bool Visit(FileObject file)
    {
        GetFileContentResult result = _fileSystem.GetFileContent(file.Path);
        if (result is GetFileContentResult.Success success)
        {
            _output.Write(success.Content);
            return true;
        }

        return false;
    }
}