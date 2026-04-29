using Itmo.ObjectOrientedProgramming.Lab4.Core.CommandBuilders.FileCommandBuilders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.ParameterLinks;

public class AddressForFileRenameParsingLink : ParameterParsingLinkBase<FileRenameCommandBuilder>
{
    public override FileRenameCommandBuilder? Parse(IEnumerator<string> arguments, FileRenameCommandBuilder builder)
    {
        builder = builder.WithAddress(arguments.Current);
        if (!arguments.MoveNext())
        {
            return builder;
        }

        return CallNext(arguments, builder);
    }
}