using Itmo.ObjectOrientedProgramming.Lab4.Core.CommandBuilders.TreeCommandBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.FlagParsers;

public class DepthForTreeListParser : IFlagArgumentParser<TreeListCommandBuilder>
{
    public string Name => "-d";

    public FlagParseResult<TreeListCommandBuilder> Parse(IEnumerator<string> arguments, TreeListCommandBuilder builder)
    {
        return new FlagParseResult<TreeListCommandBuilder>.Success(
                builder.WithDepth(int.Parse(arguments.Current)),
                arguments.MoveNext());
    }
}