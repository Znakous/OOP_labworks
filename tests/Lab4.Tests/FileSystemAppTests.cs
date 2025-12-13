using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.FileCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemApps;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemFactories;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemImpls;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

public class FileSystemAppTests
{
    [Fact]
    public void FileSystemApp_Should_CallCopy_WhenCopyCommandIsExecutedAfterConnection()
    {
        IFileSystemImplFactory mockFactory = Substitute.For<IFileSystemImplFactory>();
        IFileSystemImpl mockSystem = Substitute.For<IFileSystemImpl>();
        mockFactory.Create().Returns(mockSystem);
        var app = new FileSystemApp();
        var connect = new ConnectCommand("address", mockFactory);
        var copy = new FileCopyCommand("aboba", "abuba");

        connect.Execute(app);
        copy.Execute(app);

        mockSystem.Received(1).CopyFile(Arg.Any<string>(), Arg.Any<string>());
    }

    [Fact]
    public void FileSystemApp_ShouldNot_CallCopy_WhenCopyCommandIsExecutedWithoutConnection()
    {
        IFileSystemImplFactory mockFactory = Substitute.For<IFileSystemImplFactory>();
        IFileSystemImpl mockSystem = Substitute.For<IFileSystemImpl>();
        mockFactory.Create().Returns(mockSystem);
        var app = new FileSystemApp();
        var copy = new FileCopyCommand("aboba", "abuba");

        copy.Execute(app);

        mockSystem.Received(0).CopyFile(Arg.Any<string>(), Arg.Any<string>());
    }
}