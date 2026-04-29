using Itmo.ObjectOrientedProgramming.Lab4.Core.CommandBuilders.TreeCommandBuilders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.ParameterLinks;

public class PathForTreeGoToParsingLink : ParameterParsingLinkBase<TreeGoToCommandBuilder>
{
    public override TreeGoToCommandBuilder? Parse(IEnumerator<string> arguments, TreeGoToCommandBuilder builder)
    {
        builder = builder.WithAddress(arguments.Current);
        if (!arguments.MoveNext())
        {
            return builder;
        }

        return CallNext(arguments, builder);
    }
}