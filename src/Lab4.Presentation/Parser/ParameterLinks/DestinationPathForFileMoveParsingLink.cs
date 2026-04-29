using Itmo.ObjectOrientedProgramming.Lab4.Core.CommandBuilders.FileCommandBuilders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.ParameterLinks;

public class DestinationPathForFileMoveParsingLink : ParameterParsingLinkBase<FileMoveCommandBuilder>
{
    public override FileMoveCommandBuilder? Parse(IEnumerator<string> arguments, FileMoveCommandBuilder builder)
    {
        builder = builder.WithDestinationPath(arguments.Current);
        if (!arguments.MoveNext())
        {
            return builder;
        }

        return CallNext(arguments, builder);
    }
}