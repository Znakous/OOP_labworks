using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser;

public interface ICommandParsingLink
{
    ICommandParsingLink AddNext(ICommandParsingLink nextLink);

    ICommand? Parse(IEnumerator<string> arguments);
}