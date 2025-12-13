using Itmo.ObjectOrientedProgramming.Lab4.Core.CommandBuilders.FileCommandBuilders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.ParameterLinks;

public class NameForRenameParsingLink : ParameterParsingLinkBase<FileRenameCommandBuilder>
{
    public override FileRenameCommandBuilder? Parse(IEnumerator<string> arguments, FileRenameCommandBuilder builder)
    {
        builder = builder.WithName(arguments.Current);
        if (!arguments.MoveNext())
        {
            return builder;
        }

        return CallNext(arguments, builder);
    }
}