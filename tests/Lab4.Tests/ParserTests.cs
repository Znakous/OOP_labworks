using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.FileCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.TreeCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

public class ParserTests
{
    [Fact]
    public void Parser_Should_ParseDisconnectCommand_When_ItsGiven()
    {
        IEnumerable<string> data = ["disconnect"];
        ConsoleParser parser = new ConfiguredConsoleParserFactory(data).Create();

        CommandCreateResult result = parser.Create();

        Assert.IsType<CommandCreateResult.Success>(result);
        Assert.IsType<DisconnectCommand>(((CommandCreateResult.Success)result).Command);
    }

    [Fact]
    public void Parser_Should_ParseConnectCommand_When_ItsGiven()
    {
        IEnumerable<string> data = "connect address -m local".Split(' ');
        ConsoleParser parser = new ConfiguredConsoleParserFactory(data).Create();

        CommandCreateResult result = parser.Create();

        Assert.IsType<CommandCreateResult.Success>(result);
        Assert.IsType<ConnectCommand>(((CommandCreateResult.Success)result).Command);
    }

    [Fact]
    public void Parser_Should_ParseFileCopyCommand_When_ItsGiven()
    {
        IEnumerable<string> data = "file copy address address".Split(' ');
        ConsoleParser parser = new ConfiguredConsoleParserFactory(data).Create();

        CommandCreateResult result = parser.Create();

        Assert.IsType<CommandCreateResult.Success>(result);
        Assert.IsType<FileCopyCommand>(((CommandCreateResult.Success)result).Command);
    }

    [Fact]
    public void Parser_Should_ParseFileMoveCommand_When_ItsGiven()
    {
        IEnumerable<string> data = "file move address address".Split(' ');
        ConsoleParser parser = new ConfiguredConsoleParserFactory(data).Create();

        CommandCreateResult result = parser.Create();

        Assert.IsType<CommandCreateResult.Success>(result);
        Assert.IsType<FileMoveCommand>(((CommandCreateResult.Success)result).Command);
    }

    [Fact]
    public void Parser_Should_ParseFileDeleteCommand_When_ItsGiven()
    {
        IEnumerable<string> data = "file delete address".Split(' ');
        ConsoleParser parser = new ConfiguredConsoleParserFactory(data).Create();

        CommandCreateResult result = parser.Create();

        Assert.IsType<CommandCreateResult.Success>(result);
        Assert.IsType<FileDeleteCommand>(((CommandCreateResult.Success)result).Command);
    }

    [Fact]
    public void Parser_Should_ParseFileRenameCommand_When_ItsGiven()
    {
        IEnumerable<string> data = "file rename address aboba".Split(' ');
        ConsoleParser parser = new ConfiguredConsoleParserFactory(data).Create();

        CommandCreateResult result = parser.Create();

        Assert.IsType<CommandCreateResult.Success>(result);
        Assert.IsType<FileRenameCommand>(((CommandCreateResult.Success)result).Command);
    }

    [Fact]
    public void Parser_Should_ParseFileShowCommand_When_ItsGiven()
    {
        IEnumerable<string> data = "file show address -m console".Split(' ');
        ConsoleParser parser = new ConfiguredConsoleParserFactory(data).Create();

        CommandCreateResult result = parser.Create();

        Assert.IsType<CommandCreateResult.Success>(result);
        Assert.IsType<FileShowCommand>(((CommandCreateResult.Success)result).Command);
    }

    [Fact]
    public void Parser_Should_ParseTreeListCommand_When_ItsGiven()
    {
        IEnumerable<string> data = "tree list -d 42 -o console".Split(' ');
        ConsoleParser parser = new ConfiguredConsoleParserFactory(data).Create();

        CommandCreateResult result = parser.Create();

        Assert.IsType<CommandCreateResult.Success>(result);
        Assert.IsType<TreeListCommand>(((CommandCreateResult.Success)result).Command);
    }

    [Fact]
    public void Parser_Should_ParseTreeGoToCommand_When_ItsGiven()
    {
        IEnumerable<string> data = "tree goto chipichapa".Split(' ');
        ConsoleParser parser = new ConfiguredConsoleParserFactory(data).Create();

        CommandCreateResult result = parser.Create();

        Assert.IsType<CommandCreateResult.Success>(result);
        Assert.IsType<TreeGoToCommand>(((CommandCreateResult.Success)result).Command);
    }

    [Fact]
    public void Parser_Should_ReturnFailure_When_NotAllPositionalParametersAreSet()
    {
        IEnumerable<string> data = "file delete".Split(' ');
        ConsoleParser parser = new ConfiguredConsoleParserFactory(data).Create();

        CommandCreateResult result = parser.Create();

        Assert.IsType<CommandCreateResult.Failure>(result);
    }

    [Fact]
    public void Parser_Should_ReturnFailure_When_NotAllFlagsAreSet()
    {
        IEnumerable<string> data = "file show address".Split(' ');
        ConsoleParser parser = new ConfiguredConsoleParserFactory(data).Create();

        CommandCreateResult result = parser.Create();

        Assert.IsType<CommandCreateResult.Failure>(result);
    }

    [Fact]
    public void Parser_Should_ReturnFailure_When_GivenUnknownCommand()
    {
        IEnumerable<string> data = "file shaw address".Split(' ');
        ConsoleParser parser = new ConfiguredConsoleParserFactory(data).Create();

        CommandCreateResult result = parser.Create();

        Assert.IsType<CommandCreateResult.Failure>(result);
    }

    [Fact]
    public void Parser_Should_ReturnFailure_When_CommandFamilyIsWrong()
    {
        IEnumerable<string> data = "tree copy address1 address2".Split(' ');
        ConsoleParser parser = new ConfiguredConsoleParserFactory(data).Create();

        CommandCreateResult result = parser.Create();

        Assert.IsType<CommandCreateResult.Failure>(result);
    }
}