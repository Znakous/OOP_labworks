using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.CommandFamilyLinks;

public class TreeCommandFamilyParsingLink : CommandFamilyParsingLinkBase
{
    public TreeCommandFamilyParsingLink(ICommandParsingLink commandsParsers)
        : base(commandsParsers) { }

    public override ICommand? Parse(IEnumerator<string> arguments)
    {
        if (arguments.Current == "tree")
        {
            return arguments.MoveNext()
                ? CallCommandsParsers(arguments)
                : null;
        }

        return CallNext(arguments);
    }
}