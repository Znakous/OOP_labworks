using Itmo.ObjectOrientedProgramming.Lab4.Core.CommandBuilders.TreeCommandBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.FlagParsers;

public class DepthForTreeListFlagParser : IFlagArgumentParser<TreeListCommandBuilder>
{
    public FlagParseResult<TreeListCommandBuilder> Parse(IEnumerator<string> arguments, TreeListCommandBuilder builder)
    {
        if (arguments.Current == "-d" && arguments.MoveNext())
        {
            return new FlagParseResult<TreeListCommandBuilder>.Failure(
                    builder.WithDepth(int.Parse(arguments.Current)),
                    arguments.MoveNext());
        }

        return new FlagParseResult<TreeListCommandBuilder>.Failure(builder, false);
    }
}