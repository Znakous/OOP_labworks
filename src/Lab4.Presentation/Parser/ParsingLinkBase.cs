using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser;

public abstract class ParsingLinkBase : ICommandParsingLink
{
    private ICommandParsingLink? _nextLink;

    public ICommandParsingLink AddNext(ICommandParsingLink nextLink)
    {
        if (_nextLink is null)
        {
            _nextLink = nextLink;
        }
        else
        {
            _nextLink.AddNext(nextLink);
        }

        return this;
    }

    public abstract ICommand? Parse(IEnumerator<string> arguments);

    protected ICommand? CallNext(IEnumerator<string> arguments)
    {
        return _nextLink?.Parse(arguments) ?? null;
    }
}