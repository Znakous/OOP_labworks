using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.CommandFamilyLinks;

public abstract class CommandFamilyParsingLinkBase : ParsingLinkBase
{
    private readonly ICommandParsingLink _commandsParsers;

    protected CommandFamilyParsingLinkBase(ICommandParsingLink commandsParsers)
    {
        _commandsParsers = commandsParsers;
    }

    protected ICommand? CallCommandsParsers(IEnumerator<string> arguments)
    {
        return _commandsParsers.Parse(arguments);
    }
}