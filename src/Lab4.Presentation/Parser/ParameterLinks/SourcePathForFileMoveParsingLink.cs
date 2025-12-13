using Itmo.ObjectOrientedProgramming.Lab4.Core.CommandBuilders.FileCommandBuilders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.ParameterLinks;

public class SourcePathForFileMoveParsingLink : ParameterParsingLinkBase<FileMoveCommandBuilder>
{
    public override FileMoveCommandBuilder? Parse(IEnumerator<string> arguments, FileMoveCommandBuilder builder)
    {
        builder = builder.WithSourcePath(arguments.Current);
        if (!arguments.MoveNext())
        {
            return builder;
        }

        return CallNext(arguments, builder);
    }
}