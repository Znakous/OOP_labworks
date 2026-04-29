using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.FileCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemContexts;
using Itmo.ObjectOrientedProgramming.Lab4.Core.PathBuildingStrategies;
using Itmo.ObjectOrientedProgramming.Lab4.Core.PathParsers;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Paths;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

public class FileSystemContextTests
{
    [Fact]
    public void FileSystemApp_Should_CallCopy_WhenCopyCommandIsExecutedAfterConnection()
    {
        IFileSystem mockSystem = Substitute.For<IFileSystem>();

        mockSystem.Exists(Arg.Any<IPath>()).Returns(true);
        var app = new FileSystemContext(new PathParser(new UnixPathBuildingStrategy()));
        var connect = new ConnectCommand("address", mockSystem);
        var copy = new FileDeleteCommand("aboba");

        connect.Execute(app);
        copy.Execute(app);

        mockSystem.Received(1).DeleteFile(Arg.Any<IPath>());
    }

    [Fact]
    public void FileSystemApp_ShouldNot_CallCopy_WhenCopyCommandIsExecutedWithoutConnection()
    {
        IFileSystem mockSystem = Substitute.For<IFileSystem>();
        var app = new FileSystemContext(new PathParser(new UnixPathBuildingStrategy()));
        var copy = new FileCopyCommand("aboba", "abuba");

        copy.Execute(app);

        mockSystem.Received(0).CopyFile(Arg.Any<IPath>(), Arg.Any<IPath>());
    }
}