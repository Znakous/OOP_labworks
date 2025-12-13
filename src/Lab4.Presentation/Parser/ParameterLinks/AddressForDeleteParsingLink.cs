using Itmo.ObjectOrientedProgramming.Lab4.Core.CommandBuilders.FileCommandBuilders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.ParameterLinks;

public class AddressForDeleteParsingLink : ParameterParsingLinkBase<FileDeleteCommandBuilder>
{
    public override FileDeleteCommandBuilder? Parse(IEnumerator<string> arguments, FileDeleteCommandBuilder builder)
    {
        builder = builder.WithAddress(arguments.Current);
        if (!arguments.MoveNext())
        {
            return builder;
        }

        return CallNext(arguments, builder);
    }
}