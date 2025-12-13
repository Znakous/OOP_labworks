using Itmo.ObjectOrientedProgramming.Lab4.Core.CommandBuilders.TreeCommandBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Outputs;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.FlagParsers;

public class OutputForTreeListParser : IFlagArgumentParser<TreeListCommandBuilder>
{
    public FlagParseResult<TreeListCommandBuilder> Parse(IEnumerator<string> arguments, TreeListCommandBuilder builder)
    {
        if (arguments.Current == "-o" && arguments.MoveNext())
        {
            if (arguments.Current == "console")
            {
                return new FlagParseResult<TreeListCommandBuilder>.Success(
                    builder.WithOutput(new ConsoleOutput()),
                    arguments.MoveNext());
            }

            return new FlagParseResult<TreeListCommandBuilder>.Failure(builder, arguments.MoveNext());
        }

        return new FlagParseResult<TreeListCommandBuilder>.Failure(builder, false);
    }
}