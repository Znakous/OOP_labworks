using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.Errors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser;

public class ConsoleParser : ICommandFactory
{
    private readonly ICommandParsingLink _parsingLinks;

    private readonly IEnumerable<string> _text;

    public ConsoleParser(ICommandParsingLink parsingLinks, IEnumerable<string> text)
    {
        _parsingLinks = parsingLinks;
        _text = text;
    }

    public CommandCreateResult Create()
    {
        ICommand? command = _parsingLinks.Parse(_text.GetEnumerator());
        if (command is null)
        {
            return new CommandCreateResult.Failure(new ParsingError("Couldn't parse given text into command"));
        }

        return new CommandCreateResult.Success(command);
    }
}