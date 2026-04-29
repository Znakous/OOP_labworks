using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemObjects;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Outputs;
using System.Text;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemObjectVisitors;

public class ListVisitor : IFileSystemObjectVisitor
{
    private readonly IOutput _output;

    private readonly int _depthLimit;

    private readonly char _padding = ' ';

    private readonly char _directorySymbol = '-';

    private readonly char _fileSymbol = '_';

    private int _paddingSize = 0;

    public ListVisitor(IOutput output, int depthLimit)
    {
        _output = output;
        _depthLimit = depthLimit;
    }

    public bool Visit(DirectoryObject directory)
    {
        _output.Write(GetFormattedFor(directory, _directorySymbol));
        _paddingSize += 1;
        if (_padding >= _depthLimit)
        {
            return true;
        }

        foreach (IFileSystemObject component in directory.Contents)
        {
            component.Accept(this);
        }

        _paddingSize -= 1;
        return true;
    }

    public bool Visit(FileObject file)
    {
        _output.Write(GetFormattedFor(file, _fileSymbol));
        return true;
    }

    private string GetFormattedFor(IFileSystemObject fileSystemObject, char symbol)
    {
        var stringBuilder = new StringBuilder();
        stringBuilder.Append(_padding, _paddingSize);
        stringBuilder.Append(symbol);
        stringBuilder.AppendLine(fileSystemObject.Name);
        return stringBuilder.ToString();
    }
}