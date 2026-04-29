using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.CommandLinkFactories;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.CommandLinkFactories.CommandFamilyLinkFactories;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser;

public class ConfiguredConsoleParserFactory : IConsoleParserFactory
{
    private readonly IEnumerable<string> _text;

    public ConfiguredConsoleParserFactory(IEnumerable<string> text)
    {
        _text = text;
    }

    public ConsoleParser Create()
    {
        return new ConsoleParser(
            new FileCommandFamilyLinkFactory().Create()
                .AddNext(new TreeCommandFamilyLinkFactory().Create())
                .AddNext(new ConnectCommandLinkFactory().Create())
                .AddNext(new DisconnectCommandLinkFactory().Create()),
            _text);
    }
}