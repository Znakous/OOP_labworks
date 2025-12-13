using Itmo.ObjectOrientedProgramming.Lab4.Core.CommandBuilders.FileCommandBuilders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.ParameterLinks;

public class SourcePathForCopyParsingLink : ParameterParsingLinkBase<FileCopyCommandBuilder>
{
    public override FileCopyCommandBuilder? Parse(IEnumerator<string> arguments, FileCopyCommandBuilder builder)
    {
        builder = builder.WithSourcePath(arguments.Current);
        if (!arguments.MoveNext())
        {
            return builder;
        }

        return CallNext(arguments, builder);
    }
}