using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.CommandLinks;

public class DisconnectCommandParsingLink : ParsingLinkBase
{
    public override ICommand? Parse(IEnumerator<string> arguments)
    {
        if (arguments.Current == "disconnect")
        {
            return new DisconnectCommand();
        }

        return CallNext(arguments);
    }
}