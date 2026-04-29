using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.FileCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.CommandBuilders.FileCommandBuilders;

public class FileCopyCommandBuilder : ICommandBuilder
{
    private string? _sourcePath;
    private string? _destinationPath;

    public FileCopyCommandBuilder WithSourcePath(string sourcePath)
    {
        _sourcePath = sourcePath;
        return this;
    }

    public FileCopyCommandBuilder WithDestinationPath(string destinationPath)
    {
        _destinationPath = destinationPath;
        return this;
    }

    public ICommand? Build()
    {
        if (_sourcePath is null || _destinationPath is null)
        {
            return null;
        }

        return new FileCopyCommand(_sourcePath, _destinationPath);
    }
}